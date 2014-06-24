// include Fake lib
#I "tools/FAKE/tools"
#r @"FakeLib.dll"


open System
open System.IO

open Fake
open Fake.FileUtils
open Fake.ProcessHelper

#I "tools"
#load "XamarinHelper.fsx"

open Fake.XamarinHelper

exception Exited of int
let sh command args =
    let result =
        ExecProcess (fun info ->
            info.FileName <- command
            info.Arguments <- args
        ) TimeSpan.MaxValue

    if result <> 0 then raise (Exited result)

let buildDir = "build"
let packageDir = buildDir @@ "package"
let sdkDir = buildDir @@ "sdk"
let touchProjectDir = "src" @@ "bindings" @@ "TestFlight.Touch"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir;sdkDir; (touchProjectDir @@ "bin"); (touchProjectDir @@ "obj")]
)
(*
Target "DownloadSDK" (fun _ ->
  let download = (buildDir @@ "download")
  let api = download @@ "api.zip"
  mkdir download
  if not <| File.Exists api then
      sh "curl" (sprintf "https://www.testflightapp.com/login/?next=/sdk/download/ -v -L -o '%s'" (FullName api))

      // unzip annoyingly returns 1 on success, so we have to catch that
      try
          sh "unzip" (sprintf "%s -d %s" api download)
      with Exited 1 -> ()

      rm api

)
*)

Target "ExtractSDK" (fun _ ->
  let sdkFolder = ("." @@ "sdk");
  let pkgSerarch = sdkFolder @@ "TestFlightSDK*.*.*.zip";
  let pkg = [for f in !!pkgSerarch do yield f].Item(0);

  // unzip annoyingly returns 1 on success, so we have to catch that
  try
      sh "unzip" (sprintf "%s -d %s" pkg sdkDir)
  with Exited 1 -> ()

)

Target "BuildTouchBinding" (fun _->
  let proj = touchProjectDir @@ "TestFlight.Touch.csproj"
  BuildiOSPackage (proj, "Release")

)

let version = "3.0.2.2"

Target "CreateNugetPackage" (fun _ ->
    let libDir = packageDir @@ "lib"
    CleanDirs [packageDir;libDir;]

    //let libfiles = !!(touchProjectDir @@ "bin" @@ "Release" @@ "*.dll")

    CopyFile libDir (touchProjectDir @@ "bin" @@ "Release" @@ "TestFlight.iOS.dll")

    let files = [
      (@"lib" @@ "TestFlight.iOS.dll", Some ("lib" @@ "MonoTouch" @@ "TestFlight.iOS.dll"), None)
    ]

    NuGet(fun p ->
        {p with
            Authors = ["Matthew Hail"]
            Project = "TestFlight.Touch"
            Description = "TestFlight SDK Binding for Xamarin iOS"

            WorkingDir = packageDir
            OutputPath = packageDir

            Version = version
            Publish = false

            Files = files
        }) "template.nuspec"
)

Target "Default" DoNothing

"Clean"
==> "ExtractSDK"
==> "BuildTouchBinding"
==> "CreateNugetPackage"
==> "Default"

RunTargetOrDefault "Default"

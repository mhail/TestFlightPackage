TestFlight Binding Solution and Build Script
===

This repository conains an automated build script for creating a nuget package for *internal* use. The Nuget package can be added to a Xamarin ios project to integrate the TestFlight sdk.


1. Download TestFlight SDK and place the zip file into the sdk folder.
2. Run ```./build.sh```.
3. Collect package from ```./build/package/```

Usage:
```C#
public override bool FinishedLaunching (UIApplication app, NSDictionary options)
{
  // Initialize testflight with the app token.
	TestFlight.Touch.TestFlight.TakeOffThreadSafe("<YOUR_APP_API_TOKEN>");
}
```

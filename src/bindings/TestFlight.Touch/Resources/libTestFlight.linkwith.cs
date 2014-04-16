using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libTestFlight.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, WeakFrameworks = "AdSupport")]

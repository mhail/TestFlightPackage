using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TestTestFlight
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			TestFlight.Touch.TestFlight.TakeOffThreadSafe ("1ea9524c-a9a8-4903-82ae-7a6a9d5547f3");

			// if you want to use a different Application Delegate class from "UnitTestAppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "UnitTestAppDelegate");
		}
	}
}

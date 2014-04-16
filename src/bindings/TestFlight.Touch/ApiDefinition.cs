using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TestFlight.Touch
{

	[BaseType (typeof (NSObject))]
	public interface TestFlight {
		[Static, Export ("addCustomEnvironmentInformation:forKey:")]
		void AddCustomEnvironmentInformation (string information, string key);

		[Static, Export ("takeOff:")]
		void TakeOff (string teamToken);

		// The values that the dictionary accepts:
		// NSString ("reinstallCrashHandlers") -> NSNumber.Boolean, set to true to reinstall the crash handlers, in case some other library does
		[Static, Export ("setOptions:")]
		void SetOptions (NSDictionary options);

		[Static, Export ("passCheckpoint:")]
		void PassCheckpoint (string checkpointName);
		/* Remove in 2.0
		[Static, Export ("openFeedbackView")]
		void OpenFeedbackView ();
		*/
		[Static, Export ("submitFeedback:")]
		void SubmitFeedback (string feedback);

		[Static, Export ("setDeviceIdentifier:")]
		void SetDeviceIdentifier (string deviceIdentifer);


		[Static, Field ("TFOptionDisableInAppUpdates", "__Internal")]
		NSString OptionDisableInAppUpdates { get; }

		[Static, Field ("TFOptionFlushSecondsInterval", "__Internal")]
		NSString OptionFlushSecondsInterval { get; }

		[Static, Field ("TFOptionLogOnCheckpoint", "__Internal")]
		NSString OptionLogOnCheckpoint { get; }

		[Static, Field ("TFOptionLogToConsole", "__Internal")]
		NSString OptionLogToConsole { get; }

		[Static, Field ("TFOptionLogToSTDERR", "__Internal")]
		NSString OptionLogToSTDERR { get; }

		[Static, Field ("TFOptionReinstallCrashHandlers", "__Internal")]
		NSString OptionReinstallCrashHandlers { get; }

		[Static, Field ("TFOptionReportCrashes", "__Internal")]
		NSString OptionReportCrashes { get; }

		[Static, Field ("TFOptionSendLogOnlyOnCrash", "__Internal")]
		NSString OptionSendLogOnlyOnCrash { get; }

		[Static, Field ("OptionSessionKeepAliveTimeout", "__Internal")]
		NSString OptionSessionKeepAliveTimeout { get; }


	}
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
	//
}


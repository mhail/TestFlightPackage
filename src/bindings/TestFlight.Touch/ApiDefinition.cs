﻿//
// testflight.cs: API definition for the TestFlight SDK
//
// Authors:
//  Miguel de Icaza (miguel@xamarin.com)
//
// Copyright 2011 Xamarin Inc.
//

using System;
using MonoTouch.Foundation;

namespace TestFlight.Touch 
{

	[BaseType (typeof (NSObject))]
	public interface TestFlight {
		/// <summary>
		/// Add custom environment information
		/// If you want to track custom information such as a user name from your application you can add it here
		/// </summary>
		/// <param name="information">A string containing the environment you are storing</param>
		/// <param name="key">The key to store the information with</param>
		[Static, Export ("addCustomEnvironmentInformation:forKey:")]
		void AddCustomEnvironmentInformation (string information, string key);

		/// <summary>
		/// TakeOff with TestFlight
		/// This methode connects your app with TestFlight
		/// </summary>
		/// <param name="applicationToken">Your Application Token can be found on https://testflightapp.com/dashboard/applications/ selecting this application from the list then selecting SDK.</param>
		[Static, Export ("takeOff:")]
		void TakeOff (string applicationToken);

		// The values that the dictionary accepts:
		// TFOptionAttachBacktraceToFeedback => NSNumber.Boolean, Defaults to @NO. Setting to @YES attaches the current backtrace, with symbols, to the feedback.
		// TFOptionDisableInAppUpdates => NSNumber.Boolean, Defaults to @NO. Setting to @YES, disables the in app update screen shown in BETA apps when there is a new version available on TestFlight.
		// TFOptionLogToConsole => NSNumber.Boolean, Defaults to @YES. Prints remote logs to Apple System Log.
		// TFOptionLogToSTDERR => NSNumber.Boolean, Defaults to @YES. Sends remote logs to STDERR when debugger is attached.
		// TFOptionReinstallCrashHandlers => NSNumber.Boolean, If set to @YES: Reinstalls crash handlers, to be used if a third party library installs crash handlers overtop of the TestFlight Crash Handlers.
		// TFOptionSendLogOnlyOnCrash => NSNumber.Boolean, Defaults to @NO. Setting to @YES stops remote logs from being sent when sessions end. They would only be sent in the event of a crash.
		[Static, Export ("setOptions:")]
		void SetOptions (NSDictionary options);

		/// <summary>
		/// Track when a user has passed a checkpoint after the flight has taken off. Eg. passed level 1, posted high score
		/// </summary>
		/// <param name="checkpointName">The name of the checkpoint, this should be a static string</param>
		[Static, Export ("passCheckpoint:")]
		void PassCheckpoint (string checkpointName);

		/// <summary>
		/// Submits the feedback to the site, only if feedback is not null or empty.
		/// </summary>
		/// <param name="feedback">The feedback your user type in some text field. Or is collected in some other way</param>
		[Static, Export ("submitFeedback:")]
		void SubmitFeedback (string feedback);

	}

	[Static]
	public interface Options {

		[Field ("TFOptionDisableInAppUpdates","__Internal")]
		NSString DisableInAppUpdates { get; }

		[Field ("TFOptionFlushSecondsInterval","__Internal")]
		NSString FlushSecondsInterval { get; }

		[Field ("TFOptionLogOnCheckpoint","__Internal")]
		NSString LogOnCheckpoint { get; }

		[Field ("TFOptionLogToConsole","__Internal")]
		NSString LogToConsole { get; }

		[Field ("TFOptionLogToSTDERR","__Internal")]
		NSString LogToSTDERR { get; }

		[Field ("TFOptionReinstallCrashHandlers","__Internal")]
		NSString ReinstallCrashHandlers { get; }

		[Field ("TFOptionReportCrashes","__Internal")]
		NSString ReportCrashes { get; }

		[Field ("TFOptionSendLogOnlyOnCrash","__Internal")]
		NSString SendLogOnlyOnCrash { get; }

		[Field ("TFOptionSessionKeepAliveTimeout","__Internal")]
		NSString SessionKeepAliveTimeout { get; }
	}
}
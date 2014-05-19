using System;
using MonoTouch.Foundation;
using System.Runtime.InteropServices;
using MonoTouch.UIKit;
using System.Diagnostics;
using MonoTouch.AdSupport;

namespace TestFlight.Touch
{
	// Reference: https://github.com/mono/monotouch-bindings/tree/master/TestFlight/binding

	public partial class TestFlight
	{
		[DllImport("__Internal", EntryPoint = "TFLog")]
		private extern static void WrapperTfLog(IntPtr handle);

		public static void Log (string msg, params object [] args)
		{
			using (var nss = new NSString (string.Format (msg, args)))
				WrapperTfLog (nss.Handle);
		}

		public static void TakeOffThreadSafe(String appToken)
		{
			// http://stackoverflow.com/questions/14499334/how-to-prevent-ios-crash-reporters-from-crashing-monotouch-apps
			IntPtr sigbus = Marshal.AllocHGlobal (512);
			IntPtr sigsegv = Marshal.AllocHGlobal (512);

			// Store Mono SIGSEGV and SIGBUS handlers
			sigaction (Signal.SIGBUS, IntPtr.Zero, sigbus);
			sigaction (Signal.SIGSEGV, IntPtr.Zero, sigsegv);

			// Enable crash reporting libraries

			TestFlight.TakeOff(appToken);

			// Restore Mono SIGSEGV and SIGBUS handlers            
			sigaction (Signal.SIGBUS, sigbus, IntPtr.Zero);
			sigaction (Signal.SIGSEGV, sigsegv, IntPtr.Zero);

			Marshal.FreeHGlobal (sigbus);
			Marshal.FreeHGlobal (sigsegv);

		}

		[DllImport ("libc")]
		private static extern int sigaction (Signal sig, IntPtr act, IntPtr oact);
		enum Signal {
			SIGBUS = 10,
			SIGSEGV = 11,
			SIGPIPE = 13
		}

		private static void SetOption(NSString option, Boolean newValue)
		{
			TestFlight.SetOptions(new NSDictionary(option,NSNumber.FromBoolean(newValue)));
		}

		private static void SetOption(NSString option, Int32 newValue)
		{
			TestFlight.SetOptions(new NSDictionary(option, NSNumber.FromInt32(newValue)));
		}
		/// <summary>
		/// Setting to true, disables the in app update screen shown in BETA apps when there is a new version available on TestFlight
		/// </summary>
		/// <param name="newValue">Defaults to false</param>
		public static void SetDisableInAppUpdates(Boolean newValue)
		{
			SetOption(Options.DisableInAppUpdates,newValue);
		}

		/// <summary>
		/// Set to a number. 0 turns off the flush timer. 30 seconds is the minimum flush interval.
		/// </summary>
		/// <param name="newValue">Defaults to 60</param>
		public static void SetFlushSecondsInterval(Int32 newValue)
		{
			if (newValue < 0 || (newValue > 0 && newValue < 30))
				throw new ArgumentOutOfRangeException ("newValue", "Should be either 0 or above 30");
			SetOption (Options.FlushSecondsInterval, newValue);
		}

		/// <summary>
		/// Because logging is synchronous, if you have a high preformance app, you might want to turn this off.
		/// </summary>
		/// <param name="newValue">Defaults to true</param>
		public static void SetLogOnCheckpoint(Boolean newValue)
		{
			SetOption (Options.LogOnCheckpoint, newValue);
		}

		/// <summary>
		/// Prints remote logs to Apple System Log
		/// </summary>
		/// <param name="newValue">Defaults to true</param>
		public static void SetLogToConsole(Boolean newValue)
		{
			SetOption (Options.LogToConsole, newValue);
		}

		/// <summary>
		/// Sends remote logs to STDERR when debugger is attached
		/// </summary>
		/// <param name="newValue">Defaults to true</param>
		public static void SetLogToSTDERR(Boolean newValue)
		{
			SetOption (Options.LogToSTDERR, newValue);
		}

		/// <summary>
		/// If set to true: Reinstalls crash handlers, to be used if a third party library installs crash handlers overtop of the TestFlight Crash Handlers
		/// </summary>
		/// <param name="newValue">Only works when set to true</param>
		public static void SetReinstallCrashHandlers(Boolean newValue)
		{
			SetOption(Options.ReinstallCrashHandlers,newValue);
		}

		/// <summary>
		/// Sets the report crashes. If set to false, crash handlers are never installed. Must be set **before** calling `takeOff:`.
		/// </summary>
		/// <param name="newValue">Defaults to true</param>
		public static void SetReportCrashes(Boolean newValue)
		{
			SetOption (Options.ReportCrashes, newValue);
		}

		/// <summary>
		/// Setting to true stops remote logs from being sent when sessions end. They would only be sent in the event of a crash
		/// </summary>
		/// <param name="newValue">Defaults to false</param>
		public static void SetSendLogOnlyOnCrash(Boolean newValue)
		{
			SetOption (Options.SendLogOnlyOnCrash, newValue);
		}

		/// <summary>
		/// Sets the session keep alive timeout. This is the amount of time a user can leave the app for and still continue the same session when they come back.
		/// </summary>
		/// <param name="newValue">Defaults to 30</param>
		public static void SetSessionKeepAliveTimeout(Int32 newValue)
		{
			SetOption (Options.SessionKeepAliveTimeout, newValue);
		}
	}
}


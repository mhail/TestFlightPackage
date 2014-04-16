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
			SIGSEGV = 11
		}
	}
}


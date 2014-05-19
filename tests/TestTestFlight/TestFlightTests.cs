using System;
using NUnit.Framework;

namespace TestTestFlight
{
	[TestFixture]
	public class TestFlightTests
	{
		[Test]
		public void TestAddCustomEnvironmentInformation ()
		{
			TestFlight.Touch.TestFlight.AddCustomEnvironmentInformation ("foo", "bar");
		}

		[Test]
		public void TestLog ()
		{
			TestFlight.Touch.TestFlight.Log ("log {0} {1}", "foo", "bar");
		}

		[Test]
		public void TestSetDisableInAppUpdatesTrue ()
		{
			TestFlight.Touch.TestFlight.SetDisableInAppUpdates (true);
		}

		[Test]
		public void TestSetDisableInAppUpdatesFalse ()
		{
			TestFlight.Touch.TestFlight.SetDisableInAppUpdates (false);
		}

		[Test]
		public void TestSetFlushSecondsIntervalZero ()
		{
			TestFlight.Touch.TestFlight.SetFlushSecondsInterval (0);
		}

		[Test]
		public void TestSetFlushSecondsInterval20 ()
		{
			Assert.Throws<ArgumentOutOfRangeException>(()=>
				TestFlight.Touch.TestFlight.SetFlushSecondsInterval (20)
			);
		}

		[Test]
		public void TestSetFlushSecondsInterval31 ()
		{
			TestFlight.Touch.TestFlight.SetFlushSecondsInterval (31);
		}

		[Test]
		public void TestSetLogOnCheckpointTrue ()
		{
			TestFlight.Touch.TestFlight.SetLogOnCheckpoint (true);
		}

		[Test]
		public void TestSetLogOnCheckpointFalse ()
		{
			TestFlight.Touch.TestFlight.SetLogOnCheckpoint (false);
		}

		[Test]
		public void TestSetLogToConsoleFalse ()
		{
			TestFlight.Touch.TestFlight.SetLogToConsole (false);
		}

		[Test]
		public void TestSetLogToConsoleTrue ()
		{
			TestFlight.Touch.TestFlight.SetLogToConsole (true);
		}

		[Test]
		public void TestSetLogToSTDERRFalse ()
		{
			TestFlight.Touch.TestFlight.SetLogToSTDERR (false);
		}

		[Test]
		public void TestSetLogToSTDERRTrue ()
		{
			TestFlight.Touch.TestFlight.SetLogToSTDERR (true);
		}

		[Test]
		public void TestSetReinstallCrashHandlersFalse ()
		{
			TestFlight.Touch.TestFlight.SetReinstallCrashHandlers (false);
		}

		[Test]
		public void TestSetReinstallCrashHandlersTrue ()
		{
			TestFlight.Touch.TestFlight.SetReinstallCrashHandlers (true);
		}

		[Test]
		public void TestSetReportCrashesFalse ()
		{
			TestFlight.Touch.TestFlight.SetReportCrashes (false);
		}

		[Test]
		public void TestSetReportCrashesTrue ()
		{
			TestFlight.Touch.TestFlight.SetReportCrashes (true);
		}

		[Test]
		public void TestSetSendLogOnlyOnCrashFalse ()
		{
			TestFlight.Touch.TestFlight.SetSendLogOnlyOnCrash (false);
		}

		[Test]
		public void TestSetSendLogOnlyOnCrashTrue ()
		{
			TestFlight.Touch.TestFlight.SetSendLogOnlyOnCrash (true);
		}

		[Test]
		public void TestSetSessionKeepAliveTimeoutZero ()
		{
			TestFlight.Touch.TestFlight.SetSessionKeepAliveTimeout (0);
		}

		[Test]
		public void TestSetSessionKeepAliveTimeout20 ()
		{
			TestFlight.Touch.TestFlight.SetSessionKeepAliveTimeout (20);
		}
	}
}

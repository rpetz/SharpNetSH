using System;
using System.Diagnostics;

namespace Ignite.SharpNetSH
{
	/// <summary>
	/// A harness that executes actions using the command line
	/// </summary>
	public class CommandLineHarness : IExecutionHarness
	{
		private readonly Boolean _runSilent;
		private readonly Boolean _keepAlive;

		public CommandLineHarness(bool runSilent = true, bool keepAlive = false)
		{
			_runSilent = runSilent;
			_keepAlive = keepAlive;
		}

		public void Execute(string action)
		{
			var process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					WindowStyle = _runSilent ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Normal,
					FileName = "cmd.exe",
					Arguments = (_keepAlive ? "/k " : "/c ") + action
				}
			};
			process.Start();
		}
	}
}
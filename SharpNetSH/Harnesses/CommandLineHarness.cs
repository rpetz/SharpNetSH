using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ignite.SharpNetSH
{
	/// <summary>
	/// A harness that executes actions using the command line
	/// </summary>
	public class CommandLineHarness : IExecutionHarness
	{
		public IEnumerable<String> Execute(string action, out int exitCode)
		{
			var process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					WindowStyle = ProcessWindowStyle.Hidden,
					FileName = "cmd.exe",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					Arguments = "/c " + action
				}
			};

			process.Start();

			var lines = new List<String>();
			while (!process.StandardOutput.EndOfStream)
				lines.Add(process.StandardOutput.ReadLine());

			exitCode = process.ExitCode;

			return lines;
		}
	}
}
using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	/// <summary>
	/// A harness that simply writes actions to the console (which does not actually execute anything)
	/// </summary>
	public class ConsoleLogHarness : IExecutionHarness
	{
		public IEnumerable<string> Execute(string action, out int exitCode)
		{
			Console.WriteLine("Executing: " + action);
			exitCode = 0;
			return new List<string>();
		}
	}
}
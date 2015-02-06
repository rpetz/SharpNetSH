using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	/// <summary>
	/// A harness that simply writes actions to the console (which does not actually execute anything)
	/// </summary>
	public class ConsoleLogHarness : IExecutionHarness
	{
		public IEnumerable<String> Execute(string action)
		{
			Console.WriteLine("Executing: " + action);
			return new List<String>();
		}
	}
}
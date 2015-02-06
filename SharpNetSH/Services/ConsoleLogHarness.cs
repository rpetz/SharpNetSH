using System;

namespace Ignite.SharpNetSH
{
	/// <summary>
	/// A harness that simply writes actions to the console (which does not actually execute anything)
	/// </summary>
	public class ConsoleLogHarness : IExecutionHarness
	{
		public void Execute(string action)
		{
			Console.WriteLine("Executing: " + action);
		}
	}
}
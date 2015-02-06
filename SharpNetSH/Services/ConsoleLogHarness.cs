using System;

namespace Ignite.SharpNetSH
{
	public class ConsoleLogHarness : IExecutionHarness
	{
		public void Execute(string action)
		{
			Console.WriteLine("Executing: " + action);
		}
	}
}
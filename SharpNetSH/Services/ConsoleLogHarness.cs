using System;

namespace Ignite.SharpNetSH.Services
{
	public class ConsoleLogHarness : IConsoleHarness
	{
		public void Execute(string action)
		{
			Console.WriteLine("Executing: " + action);
		}
	}
}
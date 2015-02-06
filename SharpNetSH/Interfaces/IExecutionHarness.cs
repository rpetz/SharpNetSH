using System;

namespace Ignite.SharpNetSH
{
	public interface IExecutionHarness
	{
		void Execute(String action);
	}
}
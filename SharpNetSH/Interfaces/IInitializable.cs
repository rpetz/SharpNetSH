using System;

namespace Ignite.SharpNetSH
{
	internal interface IInitializable
	{
		void Initialize(String priorText, IExecutionHarness harness);
	}
}
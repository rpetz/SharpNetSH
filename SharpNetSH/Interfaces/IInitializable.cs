namespace Ignite.SharpNetSH
{
	internal interface IInitializable
	{
		void Initialize(string priorText, IExecutionHarness harness);
	}
}
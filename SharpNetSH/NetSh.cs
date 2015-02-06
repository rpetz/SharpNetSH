namespace Ignite.SharpNetSH
{
	public class NetSH : INetSH, IActionNameProvider
	{
		private readonly IExecutionHarness _harness;

		public NetSH(IExecutionHarness harness)
		{
			_harness = harness;
		}

		public IHttpAction Http { get { return HttpAction.CreateAction(ActionName, _harness); } }

		public string ActionName { get { return "netsh"; } }
	}
}
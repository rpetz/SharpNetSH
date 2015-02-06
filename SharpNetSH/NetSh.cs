namespace Ignite.SharpNetSH
{
	public class NetSH : INetSH, IActionNameProvider
	{
		private readonly IExecutionHarness _harness;

		public NetSH(IExecutionHarness harness)
		{
			_harness = harness;
		}

		public IHttpAction Http
		{
			get
			{
				var http = new HttpAction();
				http.Initialize(ActionName, _harness);
				return http;
			}
		}

		public string ActionName { get { return "netsh"; } }
	}
}
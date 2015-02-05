namespace Ignite.SharpNetSH
{
	public class NetSH : INetSH, IActionNameProvider
	{
		private readonly IConsoleHarness _harness;

		public NetSH(IConsoleHarness harness)
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
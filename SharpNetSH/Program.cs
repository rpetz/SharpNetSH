using System;

namespace Ignite.SharpNetSH
{
	class Program
	{
		static void Main(string[] args)
		{
			INetSH test = new NetSH(new ConsoleLogHarness());
			var http = test.Http;
			var flush = http.Flush;
			var otherFlush = http.Flush;

			flush.LogBuffer();
			flush.LogBuffer();
			flush.LogBuffer();
			otherFlush.LogBuffer();
			otherFlush.LogBuffer();
			otherFlush.LogBuffer();

			Console.ReadLine();
		}
	}
}

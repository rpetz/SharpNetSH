using System;
using System.Globalization;

namespace Ignite.SharpNetSH.HTTP
{
	public sealed class CacheEntry : IOutputObject
	{
		void IOutputObject.AddValue(String title, String value)
		{
			switch (title.ToLower())
			{
				case "url": URL = value; break;
				case "status code": StatusCode = ushort.Parse(value); break;
				case "http verb": HttpVerb = value; break;
				case "cache policy type": CachePolicyType = value; break;
				case "creation time": CreationTime = DateTimeOffset.ParseExact(value, "yyyy.M.d:HH.m.s:f", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal); break;
				case "request queue name": RequestQueueName = value; break;
				case "content type": ContentType = value; break;
				case "content encoding": ContentEncoding = value; break;
				case "headers length": HeadersLength = uint.Parse(value); break;
				case "content length": ContentLength = ulong.Parse(value); break;
				case "hit count": HitCount = ulong.Parse(value); break;
				case "force disconnect after serving": ForceDisconnectAfterServing = bool.Parse(value); break;
				default:
					throw new Exception("Invalid Raw Cache Data. Title: " + title + ", Value: " + value);
			}
		}

		public string URL { get; private set; }
		public ushort StatusCode { get; private set; }
		public string HttpVerb { get; private set; }
		public string CachePolicyType { get; private set; }
		public DateTimeOffset CreationTime { get; private set; }
		public string RequestQueueName { get; private set; }
		public string ContentType { get; private set; }
		public string ContentEncoding { get; private set; }
		public uint HeadersLength { get; private set; }
		public ulong ContentLength { get; private set; }
		public ulong HitCount { get; private set; }
		public bool ForceDisconnectAfterServing { get; private set; }
	}
}
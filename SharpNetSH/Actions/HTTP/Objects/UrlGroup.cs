using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.HTTP
{
	public sealed class UrlGroup : IOutputObject, IResponseProcessor
	{
		internal UrlGroup()
		{ }

		public String UrlGroupId { get; private set; }
		public String State { get; private set; } // TODO: Move this to an enumeration
		public dynamic Properties { get; private set; }
		public ServerSession ServerSession { get; private set; }
		public RequestQueue RequestQueue { get; set; }
			
		void IOutputObject.AddValue(string title, string value)
		{
			title = title.Trim();
			value = value.Trim();

			switch (title.ToLower())
			{
				case "url group id": UrlGroupId = value; break;
				case "state": State = value; break;
				default:
					throw new Exception("Invalid Raw Request Queue Data. Title: " + title + ", Value: " + value);
			}
		}

		object IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			return this; 
		}
	}
}
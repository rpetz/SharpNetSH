using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ignite.SharpNetSH.HTTP
{
	public sealed class TimeoutEntries : IOutputObject, IResponseProcessor
	{
		internal TimeoutEntries()
		{ }

		public ushort IdleConnectionTimeout { get; private set; }
		public ushort HeaderWaitTimeout { get; private set; }

		void IOutputObject.AddValue(String title, String value)
		{
			switch (title.ToLower())
			{
				case "idle connection timeout (secs)": IdleConnectionTimeout = ushort.Parse(value); break;
				case "header wait timeout (secs)": HeaderWaitTimeout = ushort.Parse(value); break;
				default:
					throw new Exception("Invalid Raw Timeout Data. Title: " + title + ", Value: " + value);
			}
		}

		object IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines)
		{
			this.ProcessRawData(@":\s+", responseLines.Skip(3).Where(x => !String.IsNullOrWhiteSpace(x)));
			return this;
		}
	}
}
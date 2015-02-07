using System;

namespace Ignite.SharpNetSH
{
	public class TimeoutEntries : OutputObject
	{
		public ushort IdleConnectionTimeout { get; private set; }
		public ushort HeaderWaitTimeout { get; private set; }

		internal override void AddValue(string title, string value)
		{
			switch (title.ToLower())
			{
				case "idle connection timeout (secs)": IdleConnectionTimeout = ushort.Parse(value); break;
				case "header wait timeout (secs)": HeaderWaitTimeout = ushort.Parse(value); break;
				default:
					throw new Exception("Invalid Raw Timeout Data. Title: " + title + ", Value: " + value);
			}
		}
	}
}
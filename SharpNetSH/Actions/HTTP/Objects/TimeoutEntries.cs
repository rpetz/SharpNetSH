using System;

namespace Ignite.SharpNetSH.HTTP
{
	public sealed class TimeoutEntries : IOutputObject
	{
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
	}
}
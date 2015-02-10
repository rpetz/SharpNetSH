using System;

namespace Ignite.SharpNetSH.HTTP
{
	public sealed class User : IOutputObject
	{
		internal User()
		{ }

		public String Username { get; private set; }
		public Boolean Delegate { get; private set; }
		public Boolean Listen { get; private set; }
		public String SDDL { get; private set; }

		void IOutputObject.AddValue(string title, string value)
		{
			switch (title.ToLower())
			{
				case "user": Username = value; break;
				case "delegate": Delegate = value.ToLower() == "yes"; break;
				case "listen": Listen = value.ToLower() == "yes"; break;
				case "sddl": SDDL = value; break;
				default:
					throw new Exception("Invalid Raw User Data. Title: " + title + ", Value: " + value);
			}
		}
	}
}
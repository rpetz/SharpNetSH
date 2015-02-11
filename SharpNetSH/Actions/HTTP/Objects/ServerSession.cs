using System;

namespace Ignite.SharpNetSH.HTTP
{
	public sealed class ServerSession : IOutputObject
	{
		internal ServerSession()
		{ }

		public String Version { get; private set; }
		public String State { get; private set; } // TODO: Move this to an enumeration
		public dynamic Properties { get; private set; }

		void IOutputObject.AddValue(string title, string value)
		{
			throw new NotImplementedException();
		}
	}
}
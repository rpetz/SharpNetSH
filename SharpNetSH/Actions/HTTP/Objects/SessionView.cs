using System.Collections;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.HTTP
{
	public sealed class SessionView : IOutputObject, IMultiResponseProcessor
	{
		internal SessionView()
		{ }

		void IOutputObject.AddValue(string title, string value)
		{
			throw new System.NotImplementedException();
		}

		IEnumerable IMultiResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			return new List<SessionView>();
		}
	}
}
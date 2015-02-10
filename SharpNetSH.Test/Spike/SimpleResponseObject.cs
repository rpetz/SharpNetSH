using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class SimpleResponseObject : IResponseProcessor
	{
		internal SimpleResponseObject()
		{
			
		}

		object IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines)
		{
			return this;
		}
	}
}
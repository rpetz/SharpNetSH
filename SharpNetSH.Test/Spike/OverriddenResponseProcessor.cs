using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class OverriddenResponseProcessor : IResponseProcessor
	{
		object IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines)
		{
			return new SimpleResponseObject();
		}
	}
}
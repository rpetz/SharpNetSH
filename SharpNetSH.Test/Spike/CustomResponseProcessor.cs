using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class CustomResponseProcessor : IResponseProcessor
	{
		object IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines)
		{
			return "CustomResponseProcessor";
		}
	}
}
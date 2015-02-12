using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	internal class DynamicProcessor : IResponseProcessor
	{
		StandardResponse IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			//TODO: Process the response into a dynamic object
			throw new System.NotImplementedException();
		}
	}
}
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	internal class ExitCodeProcessor : IResponseProcessor
	{
		StandardResponse IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			IResponseProcessor response = new StandardResponse();
			response.ProcessResponse(responseLines, exitCode);
			return (StandardResponse)response;
		}
	}
}
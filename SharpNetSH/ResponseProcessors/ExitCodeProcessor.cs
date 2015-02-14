using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	internal class ExitCodeProcessor : IResponseProcessor
	{
		StandardResponse IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode, String splitRegEx = null)
		{
			IResponseProcessor response = new StandardResponse();
			response.ProcessResponse(responseLines, exitCode);
			return (StandardResponse)response;
		}
	}
}
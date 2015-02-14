using System;
using System.Collections.Generic;
using System.Linq;

namespace Ignite.SharpNetSH
{
	internal class SkipHeaderProcessor : IResponseProcessor
	{
		StandardResponse IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode, String splitRegEx = null)
		{
			IResponseProcessor standardResponse = new StandardResponse();
			standardResponse.ProcessResponse(responseLines.Skip(3), exitCode);
			return (StandardResponse) standardResponse;
		}
	}
}
using System.Collections;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class OverzealousResponseProcessor : IResponseProcessor, IMultiResponseProcessor
	{
		object IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			return null;
		}

		IEnumerable IMultiResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			return null;
		}
	}
}
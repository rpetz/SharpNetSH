using System.Collections;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class MultiResponseObject : IMultiResponseProcessor
	{
		internal MultiResponseObject()
		{

		}

		IEnumerable IMultiResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			return new List<MultiResponseObject>();
		}
	}
}
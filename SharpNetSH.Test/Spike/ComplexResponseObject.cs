using System.Collections;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class ComplexResponseObject : IResponseProcessor, IMultiResponseProcessor
	{
		internal ComplexResponseObject()
		{

		}

		object IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			return this;
		}

		IEnumerable IMultiResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			return new List<ComplexResponseObject>();
		}
	}
}
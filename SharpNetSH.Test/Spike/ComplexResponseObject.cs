using System.Collections;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class ComplexResponseObject : IResponseProcessor, IMultiResponseProcessor
	{
		internal ComplexResponseObject()
		{

		}

		void IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines)
		{
		}

		IEnumerable IMultiResponseProcessor.ProcessResponse(IEnumerable<string> responseLines)
		{
			return new List<ComplexResponseObject>();
		}
	}
}
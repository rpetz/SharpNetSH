using System.Collections;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class GenericResponseObject<T> : IResponseProcessor, IMultiResponseProcessor
	{
		internal GenericResponseObject()
		{

		}

		void IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines)
		{
		}

		IEnumerable IMultiResponseProcessor.ProcessResponse(IEnumerable<string> responseLines)
		{
			return new List<GenericResponseObject<T>>();
		}
	}
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class CustomMultiResponseProcessor : IMultiResponseProcessor
	{
		IEnumerable IMultiResponseProcessor.ProcessResponse(IEnumerable<string> responseLines)
		{
			return new List<String> { "CustomMultiResponseProcessor" };
		}
	}
}
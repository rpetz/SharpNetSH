using System.Collections;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class OverriddenMultiResponseProcessor : IMultiResponseProcessor
	{
		IEnumerable IMultiResponseProcessor.ProcessResponse(IEnumerable<string> responseLines)
		{
			return new List<SimpleResponseObject>
			{
				new SimpleResponseObject(),
				new SimpleResponseObject(),
				new SimpleResponseObject(),
				new SimpleResponseObject(),
				new SimpleResponseObject(),
				new SimpleResponseObject(),
				new SimpleResponseObject(),
				new SimpleResponseObject(),
				new SimpleResponseObject(),
				new SimpleResponseObject(),
			};
		}
	}
}
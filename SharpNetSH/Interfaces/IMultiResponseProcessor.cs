using System.Collections;
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	internal interface IMultiResponseProcessor
	{
		IEnumerable ProcessResponse(IEnumerable<string> responseLines);
	}
}
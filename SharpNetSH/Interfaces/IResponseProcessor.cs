using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	internal interface IResponseProcessor
	{
		object ProcessResponse(IEnumerable<String> responseLines);
	}
}
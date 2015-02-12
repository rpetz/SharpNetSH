using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	internal interface IResponseProcessor
	{
		StandardResponse ProcessResponse(IEnumerable<String> responseLines, int exitCode);
	}
}
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	internal interface IResponseProcessor
	{
		StandardResponse ProcessResponse(IEnumerable<string> responseLines, int exitCode, string splitRegEx = null);
	}
}
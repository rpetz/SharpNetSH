using System.Collections.Generic;

namespace Ignite.SharpNetSH.HTTP
{
	public class StandardExitCodeResponseProcessor : IResponseProcessor
	{
		public object ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{ return exitCode == 0; }
	}
}
using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	internal interface IResponseProcessor
	{
		void ProcessResponse(IEnumerable<String> responseLines);
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ignite.SharpNetSH.HTTP
{
	internal class IpListenShowResponseProcessor : IMultiResponseProcessor
	{
		IEnumerable IMultiResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			var entries = new List<String>();
			if (responseLines == null) return entries;
			entries = responseLines.Skip(3).Where(line => !String.IsNullOrWhiteSpace(line)).Select(line => line.Trim()).ToList();
			return entries;
		}
	}
}
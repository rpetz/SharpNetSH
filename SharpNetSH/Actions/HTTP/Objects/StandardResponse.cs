using System;
using System.Collections.Generic;
using System.Linq;

namespace Ignite.SharpNetSH.HTTP
{
	public sealed class StandardResponse : IResponseProcessor
	{
		public String Response { get; private set; }
		public int ExitCode { get; private set; }
		public bool IsNormalExit { get; private set; }

		internal StandardResponse()
		{ }

		public object ProcessResponse(IEnumerable<string> responseLines, int exitCode)
		{
			ExitCode = exitCode;
			IsNormalExit = exitCode == 0;
			var nonEmptyLines = responseLines.Where(x => !String.IsNullOrWhiteSpace(x)).ToList();
			Response = nonEmptyLines.Any() ? nonEmptyLines.Aggregate((current, next) => current + Environment.NewLine + next) : String.Empty;
			return this;
		}
	}
}
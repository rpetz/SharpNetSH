using System;
using System.Collections.Generic;
using System.Linq;

namespace Ignite.SharpNetSH
{
	public sealed class StandardResponse : IResponseProcessor, IResponse
	{
		public String Response { get; internal set; }
		public dynamic ResponseObject { get; internal set; }
		public int ExitCode { get; internal set; }
		public bool IsNormalExit { get; internal set; }

		internal StandardResponse()
		{ }

		StandardResponse IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode, String splitRegEx = null)
		{
			ExitCode = exitCode;
			IsNormalExit = exitCode == 0;
			var nonEmptyLines = responseLines.Where(x => !String.IsNullOrWhiteSpace(x)).ToList();
			Response = nonEmptyLines.Any() ? nonEmptyLines.Aggregate((current, next) => current + Environment.NewLine + next) : String.Empty;
			return this;
		}
	}
}
using System;

namespace Ignite.SharpNetSH
{
	public interface IResponse
	{
		String Response { get; }
		dynamic ResponseObject { get; }
		int ExitCode { get; }
		bool IsNormalExit { get; }
	}
}
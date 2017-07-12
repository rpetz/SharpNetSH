namespace Ignite.SharpNetSH
{
	public interface IResponse
	{
		string Response { get; }
		dynamic ResponseObject { get; }
		int ExitCode { get; }
		bool IsNormalExit { get; }
	}
}
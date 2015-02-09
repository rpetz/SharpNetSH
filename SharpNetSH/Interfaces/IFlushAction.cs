namespace Ignite.SharpNetSH
{
	public interface IFlushAction
	{
		/// <summary>
		/// Flushes the internal buffers for the log files.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307232(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		[MethodName("logbuffer")]
		void LogBuffer();
	}
}
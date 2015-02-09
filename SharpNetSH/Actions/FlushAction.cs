namespace Ignite.SharpNetSH
{
	internal class FlushAction : IFlushAction, IActionNameProvider
	{
		public string ActionName { get { return "flush"; } }

		public void LogBuffer()
		{ throw new CannotDirectlyCallException(); }
	}
}
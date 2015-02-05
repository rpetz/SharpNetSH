using System;

namespace Ignite.SharpNetSH
{
	public interface IActionNameProvider
	{
		/// <summary>
		/// Gets the text to output to the netsh command
		/// </summary>
		String ActionName { get; }
	}
}
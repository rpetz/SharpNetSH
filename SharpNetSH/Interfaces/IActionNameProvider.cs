using System;

namespace Ignite.SharpNetSH
{
	internal interface IActionNameProvider
	{
		/// <summary>
		/// Gets the text to output to the netsh command
		/// </summary>
		string ActionName { get; }
	}
}
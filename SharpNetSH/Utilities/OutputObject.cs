using System;

namespace Ignite.SharpNetSH
{
	/// <summary>
	/// Represents an object that can be added to internally, but still visible externally.
	/// </summary>
	// NOTE: If this class were an interface we wouldn't be able to mark the 'AddValue' method as 'internal' in scope,
	// which would effectively allow for mutation by the user of this library.
	public abstract class OutputObject
	{
		internal abstract void AddValue(String title, String value);
	}
}
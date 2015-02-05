namespace Ignite.SharpNetSH
{
	public interface IHttpAction
	{
		/// <summary>
		/// Represents an additive action
		/// </summary>
		IAddAction Add { get; }

		/// <summary>
		/// Represents a removal action
		/// </summary>
		IDeleteAction Delete { get; }

		/// <summary>
		/// Represents a flushing action
		/// </summary>
		IFlushAction Flush { get; }

		/// <summary>
		/// Represents a querying action
		/// </summary>
		IShowAction Show { get; }
	}
}
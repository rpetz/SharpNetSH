namespace Ignite.SharpNetSH.WLAN
{
    public interface IWlanAction
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
        /// Represents a connecting action
        /// </summary>
        //IConnectAction Connect { get; }

        /// <summary>
        /// Represents a setting action
        /// </summary>
        ISetAction Set { get; }
        
        /// <summary>
        /// Represents a querying action
        /// </summary>
        IShowAction Show { get; }
    }
}

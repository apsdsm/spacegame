namespace SpaceGame.Interfaces
{
    /// <summary>
    /// Interface for the ship factory class.
    /// </summary>
    public interface ICollectableFactory
    {
        /// <summary>
        /// Create and return a coin.
        /// </summary>
        /// <returns>GameObject that instantiates coin prefab</returns>
        ICollectable CreateEnergyBall ();
    }
}

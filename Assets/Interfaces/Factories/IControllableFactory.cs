namespace SpaceGame.Interfaces
{
    /// <summary>
    /// Interface for the ship factory class.
    /// </summary>
    public interface IControllableFactory
    {
        /// <summary>
        /// Create and return an enemy saucer.
        /// </summary>
        /// <returns>GameObject that instantiates enemy ship prefab</returns>
        IControllable CreateShip();
    }
}

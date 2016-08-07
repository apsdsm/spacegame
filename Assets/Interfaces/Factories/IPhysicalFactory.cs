namespace SpaceGame.Interfaces
{
    /// <summary>
    /// Interface for the ship factory class.
    /// </summary>
    public interface IPhysicalFactory
    {
        /// <summary>
        /// Create and return a player ship.
        /// </summary>
        /// <returns>GameObject that instantiates player ship prefab</returns>
        IPhysical CreatePlayerShip ();

        /// <summary>
        /// Create and return an enemy ship.
        /// </summary>
        /// <returns>GameObject that instantiates enemy ship prefab</returns>
        IPhysical CreateEnemyShip ();
    }
}

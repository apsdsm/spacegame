namespace SpaceGame.Interfaces
{
    /// <summary>
    /// Interface for the ship factory class.
    /// </summary>
    public interface IBulletFactory
    {
        /// <summary>
        /// Create and return a player ship.
        /// </summary>
        /// <returns>GameObject that instantiates player ship prefab</returns>
        IShootable CreatePlayerBullet ();
    }
}

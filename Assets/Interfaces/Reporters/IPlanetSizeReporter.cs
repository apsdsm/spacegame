namespace SpaceGame.Interfaces
{
    /// <summary>
    /// Interface for the ship factory class.
    /// </summary>
    public interface IPlanetSizeReporter
    {
        /// <summary>
        /// Return the radius of a sphere collider attached to the game object
        /// </summary>
        float GetSize ();
    }
}

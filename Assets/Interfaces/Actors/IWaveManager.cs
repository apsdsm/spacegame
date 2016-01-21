using SpaceGame.Interfaces;

namespace SpaceGame.Interfaces
{
    public interface IWaveManager
    {
        /// <summary>
        ///  Return an array of all enemies currently being managed.
        /// </summary>
        IPhysical[] Ships { get; }
    }
}


// game
using SpaceGame.Events;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// Interface for the ship factory class.
    /// </summary>
    public interface IEnemyFactory
    {
        /// <summary>
        /// Called when a new enemy is created.
        /// </summary>
        event EnemyCreatedEvent onEnemyCreated;

        /// <summary>
        /// Create and return an enemy saucer.
        /// </summary>
        /// <returns>GameObject that instantiates enemy ship prefab</returns>
        IEnemy CreateSaucer();
    }
}

using SpaceGame.Interfaces;

namespace SpaceGame.Events
{
    /// <summary>
    /// Called when enemy is destroyed.
    /// </summary>
    /// <param name="enemy">Reference to enemy that will be destroyed</param>
    public delegate void EnemyDestroyedEvent(IEnemy enemy);
}

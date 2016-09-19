using SpaceGame.Interfaces;

namespace SpaceGame.Events {

    /// <summary>
    /// Called when enemy is created.
    /// </summary>
    public delegate void EnemyCreatedEvent(IEnemy enemy);
}

using SpaceGame.Actors;
using SpaceGame.Controllers;

namespace SpaceGame.Agents
{
    class EnemyAgent : Agent<Enemy>
    {
        void Awake ()
        {
            PhysicsController ship = GetComponent<PhysicsController>();
            actor = new Enemy( this, ship );
        }
    }
}

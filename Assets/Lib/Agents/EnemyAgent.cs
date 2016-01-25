using SpaceGame.Actors;
using SpaceGame.Controllers;

namespace SpaceGame.Agents
{
    class EnemyAgent : Agent<Enemy>
    {
        void Awake ()
        {
            actor = new Enemy( this, 
                               GetComponent<TransformController>(),
                               GetComponent<PhysicsController>() );
        }
    }
}

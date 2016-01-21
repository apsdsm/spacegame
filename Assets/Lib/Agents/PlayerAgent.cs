using SpaceGame.Actors;
using SpaceGame.Controllers;

namespace SpaceGame.Agents
{
    class PlayerAgent : Agent<Player>
    {
        void Awake ()
        {
            PhysicsController ship = GetComponent<PhysicsController>();
            actor = new Player( this, ship );
        }
    }
}

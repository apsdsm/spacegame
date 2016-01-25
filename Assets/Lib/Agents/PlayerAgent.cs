using SpaceGame.Actors;
using SpaceGame.Controllers;

namespace SpaceGame.Agents
{
    class PlayerAgent : Agent<Player>
    {
        void Awake ()
        {
            actor = new Player( this, 
                                GetComponent<TransformController>(),
                                GetComponent<PhysicsController>() );
        }
    }
}

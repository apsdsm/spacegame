using SpaceGame.Actors;
using SpaceGame.Controllers;
using SpaceGame.Reporters;

namespace SpaceGame.Agents
{
    class BulletAgent : Agent<Bullet>
    {
        void Awake ()
        {
            actor = new Bullet( this,
                                GetComponent<TransformController>(),
                                GetComponent<BulletCollisionReporter>() );
        }
    }
}

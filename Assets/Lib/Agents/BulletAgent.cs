using SpaceGame.Actors;
using SpaceGame.Reporters;

namespace SpaceGame.Agents
{
    class BulletAgent : Agent<Bullet>
    {
        void Awake ()
        {
            BulletCollisionReporter collisions = GetComponent<BulletCollisionReporter>();

            actor = new Bullet( this, collisions );
        }
    }
}

using SpaceGame.Actors;

namespace SpaceGame.Agents
{
    class BulletAgent : Agent<Bullet>
    {
        void Awake ()
        {
            actor = new Bullet( this );
        }
    }
}

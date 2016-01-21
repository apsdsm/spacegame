using SpaceGame.Actors;

namespace SpaceGame.Agents
{
    class WaveManagerAgent : Agent<WaveManager>
    {
        void Awake ()
        {
            actor = new WaveManager( this );
        }
    }
}

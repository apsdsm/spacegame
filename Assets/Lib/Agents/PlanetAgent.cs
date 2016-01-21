using SpaceGame.Actors;
using SpaceGame.Reporters;

namespace SpaceGame.Agents
{
    class PlanetAgent : Agent<Planet>
    {
        void Awake ()
        {
            PlanetSizeReporter size = GetComponent<PlanetSizeReporter>();
            actor = new Planet( this, size );
        }
    }
}

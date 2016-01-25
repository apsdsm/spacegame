using SpaceGame.Actors;
using SpaceGame.Controllers;
using SpaceGame.Reporters;

namespace SpaceGame.Agents
{
    class PlanetAgent : Agent<Planet>
    {
        void Awake ()
        {
            actor = new Planet( this, 
                                GetComponent<TransformController>(),
                                GetComponent<PlanetSizeReporter>() );
        }
    }
}

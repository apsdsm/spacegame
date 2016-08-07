using UnityEngine;
using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    public class PlanetFake : UFake, IPlanet
    {
        public Vector3 CoreLocation
        { 
            get { return Evaluate<Vector3>(Call("GetCoreLocation")); }
        }

        public Location GetRandomSpawnPoint()
        {
            return Evaluate<Location>(Call("GetRandomSpawnPoint"));
        }
    }
}

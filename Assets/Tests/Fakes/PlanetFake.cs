using UnityEngine;
using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    public class PlanetFake : UFake, IPlanet
    {
        public Vector3 getCoreLocationReturns;

        public Vector3 CoreLocation { get { return evaluateMethod<Vector3>("GetCoreLocation"); } }

        public SpawnPoint GetRandomSpawnPoint (float distanceFromSurface) { return evaluateMethod<SpawnPoint>("GetRandomSpawnPoint", distanceFromSurface); }
    }
}

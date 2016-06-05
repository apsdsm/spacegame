using UnityEngine;
using SpaceGame.Interfaces;
using System;

namespace SpaceGame.Tests.Fakes
{
    public class PlanetFake : IPlanet
    {

        // get core location

        public int getCoreLocationCalled = 0;

        public Vector3 getCoreLocationReturns;

        public Vector3 CoreLocation
        {
            get {
                ++getCoreLocationCalled;
                return getCoreLocationReturns;
            }
        }

        // get random position

        public int getRandomPositionCalled = 0;

        public float getRandomPositionReceivedDistanceFromSurface;

        public SpawnPoint getRandomPositionReturns;

        public SpawnPoint GetRandomSpawnPoint (float distanceFromSurface)
        {
            ++getRandomPositionCalled;
            getRandomPositionReceivedDistanceFromSurface = distanceFromSurface;

            return getRandomPositionReturns;
        }

        /// <summary>
        /// Reset fake to default values.
        /// </summary>
        public void ResetFake ()
        {
            getRandomPositionCalled = 0;
            getRandomPositionReturns = default(SpawnPoint);

            getCoreLocationCalled = 0;
            getCoreLocationReturns = default(Vector3);
        }
    }
}

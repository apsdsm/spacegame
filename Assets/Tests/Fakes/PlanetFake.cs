using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Tests.Fakes
{
    public class PlanetFake : IPlanet
    {
        // get random position

        public int getRandomPositionCalled = 0;

        public float getRandomPositionReceivedDistanceFromSurface;

        public Vector3 getRandomPositionReturns;

        public Vector3 GetRandomPosition (float distanceFromSurface)
        {
            getRandomPositionCalled++;
            getRandomPositionReceivedDistanceFromSurface = distanceFromSurface;

            return getRandomPositionReturns;
        }

        /// <summary>
        /// Reset fake to default values.
        /// </summary>
        public void ResetFake ()
        {
            getRandomPositionCalled = 0;
            getRandomPositionReturns = default(Vector3);
        }
    }
}

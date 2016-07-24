using UnityEngine;

namespace SpaceGame.Interfaces
{
    public interface IPlanet
    {
        /// <summary>
        /// Returns a random position above the surface of the planet.
        /// </summary>
        /// <param name="distanceFromSurface"></param>
        /// <returns>random spawn point above surface</returns>
        SpawnPoint GetRandomSpawnPoint ();

        /// <summary>
        /// Return the a position representing the planet's centre of mass.
        /// </summary>
        /// <returns>position of planet</returns>
        Vector3 CoreLocation { get; }
    }
}

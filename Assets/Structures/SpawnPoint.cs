using UnityEngine; 

namespace SpaceGame
{
    /// <summary>
    /// Objects in the game are instantiated at spawn points. These represent a 3d position above
    /// the surface of the planet, and an orientation for the new object's 'up' vector.
    /// </summary>
    public struct SpawnPoint
    {
        public Vector3 position;
        public Vector3 orientation;
    }
}

using UnityEngine; 

namespace SpaceGame
{
    /// <summary>
    /// Represents a location on the planet. Locations have both a positon and orientation (vector pointing away from core)
    /// </summary>
    public struct Location
    {
        public Location(Vector3 position, Vector3 orientation)
        {
            this.position = position;
            this.orientation = orientation;            
        }

        public Vector3 position;
        public Vector3 orientation;
    }
}

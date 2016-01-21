using UnityEngine;
using SpaceGame.Interfaces;

namespace SpaceGame.Reporters
{
    class PlanetSizeReporter : MonoBehaviour, IPlanetSizeReporter
    {
        // components
        private SphereCollider sphereCollider;

        // gather components
        void Awake()
        {
            sphereCollider = GetComponent<SphereCollider>();
        }

        /// <summary>
        /// Return the radius of the sphere collider
        /// </summary>
        public float GetSize()
        {
            if ( sphereCollider != null )
            {
                return sphereCollider.radius;
            }

            return 0.0f;
        }
    }
}

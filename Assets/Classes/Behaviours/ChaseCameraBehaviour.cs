using UnityEngine;
using SpaceGame.Actors;

namespace SpaceGame.Behaviours
{
    [RequireComponent(typeof(Camera))]
    public class ChaseCameraBehaviour : MonoBehaviour
    {
        public Transform target;

        public float distance = 10.0f;

        public float maxDistance = 12.0f;

        public float angle = 45.0f;

        public float angleDamping = 5.0f;

        public float rotationDamping = 4.0f;

        private Ship ship;

        void Awake()
        {
            ship = target.GetComponent<Ship>();
        }

        void LateUpdate ()
        {
            if (!target) {
                return;
            }
                

            Vector3 idealPosition = ship.position - ship.velocity + (Quaternion.AngleAxis(angle, ship.right) * ship.forward * -distance);

            transform.position = idealPosition;

            transform.LookAt(target, target.up);
        }
    }
}

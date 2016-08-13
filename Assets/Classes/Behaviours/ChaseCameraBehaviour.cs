using UnityEngine;

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

        void LateUpdate ()
        {
            if (!target) {
                return;
            }

            PhysicalBehaviour physical = target.GetComponent<PhysicalBehaviour>();

            Vector3 velocity = physical.GetVelocity();
            
            Vector3 idealPosition = target.position - velocity + (Quaternion.AngleAxis(angle, target.transform.right) * target.forward * -distance);

            transform.position = idealPosition;

            transform.LookAt(target, target.up);
        }
    }
}

using UnityEngine;

namespace SpaceGame.Behaviours
{
    public class ChaseCameraBehaviour : MonoBehaviour
    {
        public Transform target;

        public float distance = 10.0f;

        public float angle = 45.0f;

        public float angleDamping = 5.0f;

        public float rotationDaming = 4.0f;

        void LateUpdate ()
        {
            if ( !target )
            {
                return;
            }
            
            Vector3 idealPosition = target.position + ( Quaternion.AngleAxis( angle, target.transform.right ) * target.forward * -distance );
            Quaternion idealRotation = Quaternion.AngleAxis( angle, target.transform.right ) * target.rotation;

            Vector3 lerpedPosition = Vector3.Lerp( transform.position, idealPosition, Time.deltaTime * angleDamping );
            Quaternion lerpedRotation = Quaternion.Lerp( transform.rotation, idealRotation, Time.deltaTime * rotationDaming );

            transform.rotation = lerpedRotation;
            transform.position = lerpedPosition;
        }

    }
}

using UnityEngine;

namespace SpaceGame.Tests.ChaseCameraBehaviourTests
{

    [IntegrationTest.DynamicTest( "ChaseCameraBehaviourTests" )]
    class it_follows_the_target : chase_camera_behaviour_test
    {
        void TestEachFrame ()
        {
            chase_target_rigidbody.AddRelativeForce( Vector3.forward * 3.0f );

            if ( Frame == 100 )
            {
                Vector3 camToTarget = chase_target_object.transform.position - main_camera_object.transform.position;
                float distance = camToTarget.magnitude;

                AssertSimilar( distance, chase_camera_behaviour.distance, 1.0f, "should have been more or less close to target but distance was: " + distance.ToString() );
            }
        }
    }
}

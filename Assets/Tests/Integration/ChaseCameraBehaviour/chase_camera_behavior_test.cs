using UnityEngine;
using SpaceGame.Behaviours;
using TestHelpers;

namespace SpaceGame.Tests.ChaseCameraBehaviourTests
{

    public class chase_camera_behaviour_test : UTestCase
    {

        protected GameObject            main_camera_object;
        protected ChaseCameraBehaviour  chase_camera_behaviour;
        protected Camera                main_camera;
        protected GameObject            chase_target_object;
        protected Rigidbody             chase_target_rigidbody;


        public override void SetUp ()
        {
            main_camera_object = GameObject.Find( "Main Camera" );
            main_camera = main_camera_object.GetComponent<Camera>();
            chase_camera_behaviour = main_camera_object.GetComponent<ChaseCameraBehaviour>();

            chase_target_object = GameObject.Find( "TargetObject" );
            chase_target_rigidbody = chase_target_object.GetComponent<Rigidbody>();
        }

        public override void TearDown ()
        {
            main_camera_object.transform.position = Vector3.zero;

            chase_target_rigidbody.velocity = Vector3.zero;
            chase_target_rigidbody.angularVelocity = Vector3.zero;
            chase_target_rigidbody.transform.position = Vector3.zero;
        }
    }
}

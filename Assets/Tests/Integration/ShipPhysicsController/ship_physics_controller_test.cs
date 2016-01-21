using UnityEngine;
using TestHelpers;
using SpaceGame.Controllers;

namespace SpaceGame.Tests.Integration.ShipPhysicsControllerTests
{

    class ship_physics_controller_test : UTestCase
    {
        // sut
        protected PhysicsController ship_controller;

        // game object
        protected GameObject ship_object;

        // component
        protected Rigidbody rigidbody;

        override public void SetUp ()
        {
            ship_object = GameObject.Find( "TestShip" );
            ship_controller = ship_object.GetComponent<PhysicsController>();
            rigidbody = ship_object.GetComponent<Rigidbody>();
        }

        override public void TearDown ()
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.transform.position = Vector3.zero;
        }

    }
}

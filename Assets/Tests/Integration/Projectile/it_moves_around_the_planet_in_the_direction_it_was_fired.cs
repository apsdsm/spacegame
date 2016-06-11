using UnityEngine;

namespace SpaceGame.Tests.Integration.ProjectileTests
{

    [IntegrationTest.DynamicTest( "ProjectileTests" )]
    class it_moves_around_the_planet_in_the_direction_it_was_fired : projectile_test
    {

        public override void SetUp ()
        {
            base.SetUp();

            projectile.speed = 30.0f;
            projectile.lifeSpan = 2.0f;
            projectile.Shoot( Vector3.up, Vector3.forward, Vector3.zero );
        }

        void TestEachFrame ()
        {
            float distanceTravelled = ( projectile_object.transform.position ).magnitude;

            if (TotalTime > 1.0f)
            {
                float distanceFromCore = projectile_object.transform.position.magnitude;

                AssertSimilar(1.0f, distanceFromCore);
            }
        }

    }
}


using UnityEngine;

namespace SpaceGame.Tests.Integration.ProjectileTests
{

    [IntegrationTest.DynamicTest("ProjectileTests")]
    class it_damages_objects_with_damagable_behaviour : projectile_test
    {

        public override void SetUp ()
        {
            base.SetUp();

            projectile.speed = 10.0f;
            projectile.lifeSpan = 0.5f;
            projectile.Shoot(Vector3.up, Vector3.forward, Vector3.zero);
        }

        void TestEachFrame ()
        {
            if (TotalTime > 0.5f) {
                AssertThat(projectile_object == null);
            }
        }
    }
}

using UnityEngine;
using SpaceGame.Behaviours;
using Flexo;
using TestHelpers;

namespace SpaceGame.Tests.Integration.PhysicalBehaviourTests
{
    class physical_behaviour_test : UTestCase
    {
        protected GameObject physical_object;
        protected PhysicalBehaviour physical;

        public override void SetUp ()
        {
            base.SetUp();

            physical_object = new FlexoGameObject("player").With<PhysicalBehaviour>(out physical);
        }

        public override void TearDown ()
        {
            base.TearDown();

            if (physical_object != null) GameObject.Destroy(physical_object);
        }
    }
}

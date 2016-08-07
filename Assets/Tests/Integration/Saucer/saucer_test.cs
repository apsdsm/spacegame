using UnityEngine;
using SpaceGame.Actors;
using Flexo;
using TestHelpers;

namespace SpaceGame.Tests.Integration.SaucerTests
{
    class saucer_test : UTestCase
    {
        protected GameObject saucer_object;
        protected Saucer saucer;

        public override void SetUp ()
        {
            base.SetUp();

            saucer_object = new FlexoGameObject("enemy").With<Saucer>(out saucer);

        }

        public override void TearDown ()
        {
            base.TearDown();

            if (saucer_object != null) GameObject.Destroy(saucer_object);
        }
    }
}

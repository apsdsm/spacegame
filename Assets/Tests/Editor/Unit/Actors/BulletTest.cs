using UnityEngine;
using NUnit.Framework;
using NSubstitute;
using SpaceGame.Actors;
using SpaceGame.Interfaces;
using Fletch;

namespace SpaceGame.Tests.Unit.Actors
{
    [TestFixture]
    class BulletTest
    {
        Bullet bullet;

        IAgent agent;

        [SetUp]
        public void setup ()
        {
            agent = Substitute.For<IAgent>();

            bullet = new Bullet( agent );
        }

        [Test]
        public void it_moves_in_the_direction_it_is_fired ()
        {
            bullet.speed = 10.0f;

            bullet.Shoot( Vector3.zero, Vector3.forward );

            bullet.Update( 1.0f );

            agent.Received().Position = (Vector3.forward * 10.0f * 1.0f);
        }
    }
}

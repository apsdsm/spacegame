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
        ITransformController transform;
        IBulletCollisionReporter collisions;

        [SetUp]
        public void setup ()
        {
            agent = Substitute.For<IAgent>();
            transform = Substitute.For<ITransformController>();
            collisions = Substitute.For<IBulletCollisionReporter>();

            bullet = new Bullet( agent, transform, collisions );
        }

        [Test]
        public void it_moves_in_the_direction_it_is_fired ()
        {
            bullet.speed = 10.0f;

            bullet.Shoot( Vector3.zero, Vector3.forward );

            bullet.Update( 1.0f );

            transform.Received().Position = (Vector3.forward * 10.0f * 1.0f);
        }

        [Test]
        public void it_vanishes_when_it_reaches_its_range ()
        {
            bullet.speed = 10.0f;

            bullet.Shoot( Vector3.zero, Vector3.forward );

            bullet.Update( 3.0f );

            agent.Received().Destroy();
        }
    }
}

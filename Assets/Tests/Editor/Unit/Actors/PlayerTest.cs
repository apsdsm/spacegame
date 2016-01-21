using UnityEngine;
using NUnit.Framework;
using NSubstitute;
using SpaceGame.Actors;
using SpaceGame.Interfaces;
using Fletch;

namespace SpaceGame.Tests.Unit.Actors
{

    [ TestFixture ]
    class PlayerTests
    {
        Player player;

        IAgent agent;
        IPhysicsController ship;
        IShootable bullet;
        IBulletFactory bullets;
        IInputService input;
        IGravityService gravity;
        IRegistryService registry;
        
        [SetUp]
        public void setup ()
        {
            agent = Substitute.For<IAgent>();
            ship = Substitute.For<IPhysicsController>();
            bullet = Substitute.For<IShootable>();
            bullets = Substitute.For<IBulletFactory>();
            input = Substitute.For<IInputService>();
            gravity = Substitute.For<IGravityService>();
            registry = Substitute.For<IRegistryService>();

            bullets.CreatePlayerBullet().Returns( bullet );

            player = new Player( agent, ship, bullets, input, gravity, registry );
        }

        [Test]
        public void it_lets_the_user_control_the_ship_velocity ()
        {
            input.GetMovement().Returns( Vector2.up );

            player.Update();

            input.Received().GetMovement();
            ship.Received().AddRelativeForce( Vector3.forward );
        }

        [Test]
        public void it_lets_the_user_control_the_ship_rotation ()
        {
            input.GetMovement().Returns( Vector2.right );

            player.Update();

            input.Received().GetMovement();
            ship.Received().AddRelativeTorque( Vector3.up );
        }

        [Test]
        public void it_lets_the_user_fire_bullets ()
        {
            input.GetWeaponFired().Returns( true );

            player.Update();

            bullets.Received().CreatePlayerBullet();
        }

        [Test]
        public void it_fires_bullets_from_in_front_of_the_ship ()
        {
            agent.Forward.Returns( Vector3.forward );
            agent.Position.Returns( Vector3.zero );
            input.GetWeaponFired().Returns( true );

            player.Update();

            Vector3 bulletStartPosition = Vector3.zero + Vector3.forward * 1.0f;

            bullet.Received().Shoot( bulletStartPosition, Vector3.forward );
        }

        [Test]
        public void it_adds_itself_to_the_registry ()
        {
            registry.Received().Register<IPhysical>( "Player", player );
        }

        [Test]
        public void it_adds_itself_to_the_gravity_list ()
        {
            gravity.Received().Register( player );
        }

    }
}
using UnityEngine;
using NUnit.Framework;
using NSubstitute;
using SpaceGame.Actors;
using SpaceGame.Interfaces;
using Fletch;

namespace SpaceGame.Tests.Unit.Actors
{
    [ TestFixture ]
    class WaveManagerTest
    {
        WaveManager manager;
        IAgent agent;
        IShipFactory factory;
        IGravityService gravity;
        IRegistryService registry;
        IPlanet planet;
        IPhysical ship;

        [ SetUp ]
        public void setup ()
        {
            // mocks
            agent = Substitute.For<IAgent>();
            factory = Substitute.For<IShipFactory>();
            ship = Substitute.For<IPhysical>();
            gravity = Substitute.For<IGravityService>();
            registry = Substitute.For<IRegistryService>();
            planet = Substitute.For<IPlanet>();

            // mock behaviour
            factory.CreateEnemyShip().Returns( ship );
            
            // sut
            manager = new WaveManager( agent, factory, gravity, registry );

            // emulate call back from registry service
            manager.Planet = planet;
        }

        [ Test ]
        public void it_starts_with_no_enemies_spawned ()
        {
            Assert.AreEqual( 0, manager.Ships.Length );
        }

        [ Test ]
        public void it_spawns_new_enemies_on_update ()
        {
            manager.Update( 1.0f );

            Assert.AreEqual( 1, manager.Ships.Length );
            factory.Received().CreateEnemyShip();
        }

        [ Test ]
        public void it_does_not_spawn_more_enemies_than_the_max_number ()
        {
            manager.MaxEnemies = 1;

            manager.Update( 1.0f );
            manager.Update( 1.0f );

            Assert.AreEqual( 1, manager.Ships.Length );
        }

        [ Test ]
        public void it_does_not_spawn_an_enemy_until_after_a_cooldown ()
        {
            manager.MaxEnemies = 2;
            manager.SpawnCooldown = 1.0f;

            manager.Update( 0.5f );

            Assert.AreEqual( 0, manager.Ships.Length );

            manager.Update( 1.0f );

            Assert.AreEqual( 1, manager.Ships.Length );
        }

        [Test]
        public void it_places_enemies_above_the_surface_of_the_planet ()
        {
            manager.SpawnHeight = 10.0f;
            planet.GetRandomPosition( 10.0f ).Returns( Vector3.one );

            manager.Update( 1.0f );

            planet.Received().GetRandomPosition( 10.0f );
            factory.Received().CreateEnemyShip();
            ship.Received().SetPosition( Vector3.one );

        }

        [Test]
        public void it_adds_enemies_to_the_gravity_list ()
        {
            manager.Update( 1.0f );

            gravity.Received().Register( (IPhysical)ship );
        }

        [ Test ]
        public void it_provides_an_array_of_all_enemies ()
        {
            manager.Update( 1.0f );

            IPhysical[] enemies = manager.Ships;

            Assert.AreEqual( 1, enemies.Length );
            Assert.IsTrue( enemies[ 0 ] is IPhysical );
        }

       
    }
}

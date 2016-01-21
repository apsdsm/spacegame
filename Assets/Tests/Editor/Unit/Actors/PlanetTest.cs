using UnityEngine;
using NUnit.Framework;
using NSubstitute;
using SpaceGame.Actors;
using SpaceGame.Interfaces;
using Fletch;

namespace SpaceGame.Tests.Unit.Actors
{
    [ TestFixture ]
    class PlanetTest
    {
        Planet planet;

        IAgent agent;
        IGravityService gravity;
        IRegistryService registry;
        IPlanetSizeReporter size;

        [ SetUp ]
        public void setup ()
        {
            agent = Substitute.For<IAgent>();
            gravity = Substitute.For<IGravityService>();
            registry = Substitute.For<IRegistryService>();
            size = Substitute.For<IPlanetSizeReporter>();

            planet = new Planet( agent, size, gravity, registry );
        }

        [ Test ]
        public void it_exerts_gravity_on_everything_in_the_gravity_list ()
        {

            IPhysical target = Substitute.For<IPhysical>();
            IPhysical[] target_list = new IPhysical[] { target };

            gravity.GetTargets().Returns( target_list );
            target.GetPosition().Returns( new Vector3( 0.0f, 10.0f, 0.0f ) );
            agent.Position.Returns( new Vector3( 0.0f, 0.0f, 0.0f ) );

            planet.Update();
            target.Received().AddForce( new Vector3( 0.0f, -10.0f, 0.0f ) );
        }

        [ Test ]
        public void it_provides_a_random_point_a_given_distance_above_its_surface ()
        {
            size.GetSize().Returns( 10.0f );

            Vector3 randomPosition1 = planet.GetRandomPosition( 10.0f );
            Vector3 randomPosition2 = planet.GetRandomPosition( 10.0f );

            Assert.False( randomPosition1 == Vector3.zero );
            Assert.False( randomPosition1 == randomPosition2 );

            float difference = Mathf.Abs( randomPosition1.magnitude - 20.0f );

            Assert.That( difference < 0.1f );
        }

        [Test]
        public void it_adds_itself_to_the_registry ()
        {
            registry.Received().Register<IPlanet>( "Planet", planet );
        }
    }
}

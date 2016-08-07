using UnityEngine;
using SpaceGame;
using SpaceGame.Interfaces;
using TestHelpers;
using System;

namespace SpaceGame.Tests.Fakes
{
    public class PhysicalFake : UFake, IPhysical
    {
        public void AddForce(Vector3 force)
        {
            Evaluate(Call("AddForce").With(force));
        }

        public Location GetCurrentLocation()
        {
            return Evaluate<Location>(Call("GetCurrentLocation"));
        }

        public void MoveToLocation(Location location)
        {
            Evaluate(Call("MoveToLocation").With(location));
        }
    }
}

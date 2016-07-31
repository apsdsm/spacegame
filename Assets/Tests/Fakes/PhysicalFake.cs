using UnityEngine;
using SpaceGame;
using SpaceGame.Interfaces;
using TestHelpers;
using System;

namespace SpaceGame.Tests.Fakes
{
    public class PhysicalFake : UFake, IPhysical
    {
        public void AddForce (Vector3 force) { evaluateMethod("AddForce", force); }

        public Location GetCurrentLocation () { return evaluateMethod<Location>("GetCurrentLocation"); }

        public void MoveToLocation (Location location) { evaluateMethod("MoveToLocation", location); }
    }
}

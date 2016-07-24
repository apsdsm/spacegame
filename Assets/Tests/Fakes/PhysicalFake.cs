using UnityEngine;
using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    public class PhysicalFake : UFake, IPhysical
    {

        public void AddForce (Vector3 force) { evaluateMethod("AddForce", force); }

        public Vector3 Position
        {
            set { evaluateMethod("SetPosition", value); }
            get { return evaluateMethod<Vector3>("GetPosition"); }
        }

        public Vector3 Up
        {
            set { evaluateMethod("SetUp", value); }
            get { return evaluateMethod<Vector3>("GetUp"); }
        }
    }
}

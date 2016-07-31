using UnityEngine;
using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    public class CollectableFake : UFake, ICollectable
    {

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

using UnityEngine;
using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    public class CollectableFake : UFake, ICollectable
    {

        public void MoveToLocation(Location location)
        {
            Evaluate(Call("MoveToLocation").With(location));
        }

        public Vector3 Position
        {
            set {  Evaluate(Call("SetPosition").With(value)); }

            get {  return Evaluate<Vector3>(Call("GetPosition")); }
        }

        public Vector3 Up
        {
            set { Evaluate(Call("SetUp").With(value)); }

            get { return Evaluate<Vector3>(Call("GetUp")); }
        }
    }
}

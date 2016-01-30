using UnityEngine;
using SpaceGame.Interfaces;
using System;

namespace SpaceGame.Tests.Fakes
{
    public class PhysicalFake : IPhysical
    {

        public int addForceCalled = 0;
        public Vector3 addForceForceValue;
        public int getPositionCalled = 0;
        public int setPositionCalled = 0;
        public Vector3 setPositionPositionValue;

        public void AddForce (Vector3 force)
        {
            addForceForceValue = force;
            addForceCalled++;
        }

        public Vector3 GetPosition ()
        {
            getPositionCalled++;
            return Vector3.zero;
        }

        public void SetPosition (Vector3 position)
        {
            setPositionPositionValue = position;
            setPositionCalled++;
        }
    }
}

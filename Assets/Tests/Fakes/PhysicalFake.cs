using UnityEngine;
using SpaceGame.Interfaces;
using System;

namespace SpaceGame.Tests.Fakes
{
    public class PhysicalFake : IPhysical
    {

        // add force

        public int addForceCalled = 0;
        public Vector3 addForceReceivedForce;

        public void AddForce (Vector3 force)
        {
            addForceReceivedForce = force;
            addForceCalled++;
        }

        // Position getter/setter

        public int positionSet = 0;
        public Vector3 positonSetWith;
        public int positionGet = 0;
        public Vector3 positionGetReturns;

        public Vector3 Position
        {
            set {
                positionSet++;
                positonSetWith = value;
            }
            get {
                positionGet++;
                return positionGetReturns;
            }
        }

        // get position

        public int getPositionCalled = 0;

        public Vector3 getPositionReturns;

        public Vector3 GetPosition ()
        {
            getPositionCalled++;
            return getPositionReturns;
        }

        // set position

        public int setPositionCalled = 0;

        public Vector3 setPositionPositionValue;

        public void SetPosition (Vector3 position)
        {
            setPositionPositionValue = position;
            setPositionCalled++;
        }

        /// <summary>
        /// Reset fake to default values.
        /// </summary>
        public void ResetFake ()
        {
            //addForceCalled = 0;
            //getPositionCalled = 0;
            //getPositionReturns = default(Vector3);
            //setPositionCalled = 0;
        }
    }
}

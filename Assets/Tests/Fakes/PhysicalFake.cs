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
        public Vector3 positionSetWith;
        public int positionGet = 0;
        public Vector3 positionGetReturns;

        public Vector3 Position
        {
            set {
                positionSet++;
                positionSetWith = value;
            }

            get {
                positionGet++;
                return positionGetReturns;
            }
        }

        // Up getter/setter

        public int upSet = 0;
        public Vector3 upSetWith;
        public int upGet = 0;
        public Vector3 upGetReturns;

        public Vector3 Up
        {
            set {
                upSet++;
                upSetWith = value;
            }

            get {
                upGet++;
                return upGetReturns;
            }
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

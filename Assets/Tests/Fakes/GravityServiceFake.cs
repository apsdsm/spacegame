using UnityEngine;
using SpaceGame.Interfaces;
using System.Collections;
using System;

namespace SpaceGame.Tests.Fakes
{

    public class GravityServiceFake : MonoBehaviour, IGravityService {

        public int deregisterCalled = 0;
        public int flushCalled = 0;
        public int getTargetsCalled = 0;
        public int registerCalled = 0;
        public PhysicalFake physicalFake;

        public void Deregister (IPhysical entity)
        {
            deregisterCalled++;
        }

        public void Flush ()
        {
            flushCalled++;
        }

        public IPhysical[] Targets ()
        {
            getTargetsCalled++;

            physicalFake = new PhysicalFake();

            return new PhysicalFake[] { physicalFake };
        }

        public void Register (IPhysical entity)
        {
            registerCalled++;
        }
    }
}
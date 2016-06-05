using System;
using UnityEngine;

namespace Fletch.Fakes
{

    /// <summary>
    /// This fake should allow you to test that your objects are interacting with
    /// the Registry class as expected. It goes without saying this service should
    /// not be used outside of a test environment.
    /// </summary>
    public class RegistryServiceFake : MonoBehaviour, IRegistryService
    {
        // registration

        public int registrationsCalled = 0;

        public Registration[] registrationsReturns;

        public Registration[] Registrations
        {
            get
            {
                if (registrationsReturns == null)
                {
                    registrationsReturns = new Registration[0];
                }

                registrationsCalled++;
                return registrationsReturns;
            }
        }

        // deregister

        public int deregisterCalled = 0;

        public Type deregisterReceivedType;

        public string deregisterReceivedIdentifier;

        public void Deregister<T>(string identifier)
        {
            deregisterCalled++;
            deregisterReceivedType = typeof(T);
            deregisterReceivedIdentifier = identifier;
        }

        // flush

        public int flushCalled = 0;

        public void Flush ()
        {
            flushCalled++;
        }

        // Lookup

        public int lookUpCalled = 0;

        public Type lookUpReceivedType;

        public string lookUpReceivedIdentifier;

        public object lookUpReturns;
    
        public T LookUp<T>(string identifier)
        {
            lookUpCalled++;

            lookUpReceivedType = typeof(T);

            lookUpReceivedIdentifier = identifier;

            if (lookUpReturns == null)
            {
                lookUpReturns = default(T);
            }
            
            return (T)lookUpReturns;
        }

        // register

        public int registerCalled = 0;

        public Type registerReceivedType;

        public string registerReceivedIdentifier;

        public object registerReceivedReference;

        public void Register<T>(string identifier, object reference)
        {
            registerCalled++;

            registerReceivedType = typeof(T);

            registerReceivedIdentifier = identifier;

            registerReceivedReference = reference;
        }

        // reserve

        public int reserveCalled = 0;

        public Type reserveReceivedType;

        public string reserveReceivedIdentifier;

        public object reserveReceivedReserver;

        public void Reserve<T>(string identifier, object reserver)
        {
            reserveCalled++;

            reserveReceivedType = typeof(T);

            reserveReceivedIdentifier = identifier;

            reserveReceivedReserver = reserver;
        }

        /// <summary>
        /// Will reset the fake to its default settings.
        /// </summary>
        public void ResetFake ()
        {
            registrationsCalled = 0;
            registrationsReturns = new Registration[0];
            deregisterCalled = 0;
            flushCalled = 0;
            lookUpCalled = 0;
            lookUpReturns = default(object);
            registerCalled = 0;
            reserveCalled = 0;
        }
    }
}

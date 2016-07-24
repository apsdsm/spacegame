using System;
using UnityEngine;
using TestHelpers;

namespace Fletch.Fakes
{

    /// <summary>
    /// This fake should allow you to test that your objects are interacting with
    /// the Registry class as expected. It goes without saying this service should
    /// not be used outside of a test environment.
    /// </summary>
    public class RegistryServiceFake : UFake, IRegistryService
    {
        public Registration[] Registrations
        {
            get { return evaluateMethod<Registration[]>("Registrations"); }
        }

        public void Deregister<T> (string identifier) { evaluateMethod("Deregister", identifier); }

        public void Flush () { evaluateMethod("Flush"); }

        public T LookUp<T> (string identifier) { return evaluateMethod<T>("Lookup"); }

        public void Register<T> (string identifier, object reference) { evaluateMethod("Register", identifier, reference); }

        public void Reserve<T> (string identifier, object reserver) { evaluateMethod("Reserve", identifier, reserver); }
    }
}

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
            get { return Evaluate<Registration[]>(Call("Registrations")); }
        }

        public void Deregister<T>(string identifier)
        {
            Evaluate(Call("Deregister").With(identifier));
        }

        public void Flush()
        {
            Evaluate(Call("Flush"));
        }

        public T LookUp<T>(string identifier)
        {
            return Evaluate<T>(Call<T>("LookUp").With(identifier));
        }

        public void Register<T>(string identifier, object reference)
        {
            Evaluate(Call<T>("Register").With(identifier, reference));
        }

        public void Reserve<T>(string identifier, object reserver)
        {
            Evaluate(Call<T>("Reserve").With(identifier, reserver));
        }
    }
}

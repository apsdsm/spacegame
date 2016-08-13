using System;
using System.Collections.Generic;

namespace Fletch
{
    /// <summary>
    /// Holds a single object registration for any class that implements IRegistryService
    /// </summary>
    public struct RegistrationList
    {
        // public registration identifier
        public string listName;

        // type of the object being resitered
        public Type type;

        // registrations in this list
        public List<object> registrations;
    }
}
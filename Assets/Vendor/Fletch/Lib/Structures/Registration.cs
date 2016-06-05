using System;

namespace Fletch
{
    /// <summary>
    /// Holds a single object registration for any class that implements IRegistryService
    /// </summary>
    public struct Registration
    {
        // type of the object being resitered
        public Type type;

        // public registration identifier
        public string identifier;

        // reference to the object being registered
        public object reference;
    }
}
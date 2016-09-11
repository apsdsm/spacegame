using System;

namespace SpaceGame.Exceptions
{
    /// <summary>
    /// Called when a class has a null value where it should have a reference to object.
    /// </summary>
    public class ReferenceNotFoundException : Exception
    {
        public ReferenceNotFoundException()
        { }

        public ReferenceNotFoundException(string message) : base(message)
        { }

        public ReferenceNotFoundException(string message, Exception inner) : base(message, inner)
        { }
    }
}


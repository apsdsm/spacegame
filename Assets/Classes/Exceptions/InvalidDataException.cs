using System;

namespace SpaceGame.Exceptions
{
    /// <summary>
    /// Called when a data obejct is not set up correctly or has invalid data.
    /// </summary>
    public class InvalidDataException : Exception
    {
        public InvalidDataException()
        { }

        public InvalidDataException(string message) : base(message)
        { }

        public InvalidDataException(string message, Exception inner) : base(message, inner)
        { }
    }
}


using System;

namespace SpaceGame.Exceptions
{
    /// <summary>
    /// Called when a class isn't able to resolve all its dependencies.
    /// </summary>
    public class DependenciesNotMetException : Exception
    {
        public DependenciesNotMetException ()
        { }

        public DependenciesNotMetException ( string message ) : base( message )
        { }

        public DependenciesNotMetException ( string message, Exception inner ) : base( message, inner )
        { }
    }
}


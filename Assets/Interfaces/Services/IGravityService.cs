
namespace SpaceGame.Interfaces
{
    public interface IGravityService
    {
        /// <summary>
        /// Add an entity to the list of things that will be effected by gravity.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        void Register ( IPhysical entity );

        /// <summary>
        /// Remove an entity from the list of things that will be effected by gravity.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        void Deregister ( IPhysical entity );

        /// <summary>
        /// Remove everything from the list.
        /// </summary>
        void Flush ();

        /// <summary>
        /// Return an array of targets that should have gravity applied to them.
        /// </summary>
        /// <returns></returns>
        IPhysical[] GetTargets ();
    }
}

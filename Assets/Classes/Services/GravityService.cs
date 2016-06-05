using UnityEngine;
using System.Collections.Generic;
using SpaceGame.Interfaces;

namespace SpaceGame.Services
{

    public class GravityService : MonoBehaviour, IGravityService
    {

        List<IPhysical> targets = new List<IPhysical>();

        /// <summary>
        /// Adds the entity to the list of things that will affected by gravity.
        /// </summary>
        /// <param name="entity">entity to add</param>
        public void Register ( IPhysical entity )
        {
            targets.Add( entity );
        }

        /// <summary>
        /// Removes an entity from the list of things that will be affected by gravity.
        /// </summary>
        /// <param name="entity">entity to remove</param>
        public void Deregister ( IPhysical entity )
        {
            targets.Remove( entity );
        }

        /// <summary>
        /// Remove everything from the gravity list.
        /// </summary>
        public void Flush ()
        {
            targets.Clear();
        }

        /// <summary>
        /// Return an array of targets to apply gravity to.
        /// </summary>
        /// <returns></returns>
        public IPhysical[] Targets ()
        {
            return targets.ToArray();
        }
    }
}

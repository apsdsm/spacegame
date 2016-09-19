using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using SpaceGame.Events;

namespace SpaceGame.Interfaces
{
    public interface IEnemy
    {
        /// <summary>
        /// Move the enemy to a new location.
        /// </summary>
        /// <param name="location">location to move to</param>
        void MoveToLocation(Location location);

        /// <summary>
        /// Should be called when enemy is destroyed.
        /// </summary>
        event EnemyDestroyedEvent destroyed;

        /// <summary>
        /// The transform for the enemy.
        /// </summary>
        Transform transform { get; }
    }
}

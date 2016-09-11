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
        void MoveToLocation(Location location);

        event EnemyDestroyedEvent destroyed;
    }
}

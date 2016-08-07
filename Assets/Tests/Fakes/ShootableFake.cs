﻿using UnityEngine;
using SpaceGame.Interfaces;
using TestHelpers;

namespace SpaceGame.Tests.Fakes
{
    class ShootableFake : UFake, IShootable
    {
        public void Shoot (Vector3 startingPosition, Vector3 direction, Vector3 gravityCore) 
        { 
            Evaluate(Call("Shoot").With(startingPosition, direction, gravityCore));
        }
    }
}

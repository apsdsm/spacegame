using UnityEngine;
using System.Collections.Generic;
using System;

namespace SpaceGame
{
    /// <summary>
    /// Represents game data
    /// </summary>
    [Serializable]
    public class WaveData : ScriptableObject
    {
        /// <summary>
        /// A single wave held by wave data
        /// </summary>
        [Serializable]
        public class Wave
        {
            public int saucers;
            public int time;
        }

        public Wave[] waves;
    }
}
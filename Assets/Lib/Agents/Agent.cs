using UnityEngine;
using SpaceGame.Interfaces;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace SpaceGame.Agents
{
    public class Agent<T> : MonoBehaviour, IAgent
    {

        // actor that belongs to this agent
        public T actor;

        // reference to actor as an updatable object
        private IUpdatable updatable;

        // constructor
        void Start ()
        {
            updatable = actor as IUpdatable;
        }

        /// <summary>
        /// Destroy the game object associated with the agent.
        /// </summary>
        public void Destroy ()
        {
            GameObject.Destroy( gameObject );
        }

        /// <summary>
        /// Return a reference to the actor belonging to this agent.
        /// </summary>
        public T Actor
        {
            get { return actor; }
        }

        /// <summary>
        /// if the actor is updatable, update it.
        /// </summary>
        void Update ()
        {
            if ( updatable != null )
            {
                updatable.Update( Time.deltaTime );
            }
        }
    }
}

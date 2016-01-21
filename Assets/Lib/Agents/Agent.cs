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

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public Quaternion Rotation
        {
            get { return transform.rotation; }
            set { transform.rotation = value; }
        }

        public Vector3 Forward
        {
            get { return transform.forward; }
            set { transform.forward = value; }
        }

        public Vector3 Up
        {
            get { return transform.up; }
            set { transform.up = value; }
        }

        public Vector3 Right
        {
            get { return transform.right; }
            set { transform.right = value; }
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

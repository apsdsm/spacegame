using UnityEngine;
using SpaceGame.Interfaces;
using System;

namespace SpaceGame.Controllers
{
    class TransformController : MonoBehaviour, ITransformController
    {
        // current position
        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        // current rotation
        public Quaternion Rotation
        {
            get { return transform.rotation; }
            set { transform.rotation = value; }
        }

        // forward vector
        public Vector3 Forward
        {
            get { return transform.forward; }
            set { transform.forward = value; }
        }

        // up vector
        public Vector3 Up
        {
            get { return transform.up; }
            set { transform.up = value; }
        }

        // right vector
        public Vector3 Right
        {
            get { return transform.right; }
            set { transform.right = value; }
        }
    }
}

using UnityEngine;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// A collectable object can be picked up by the player.
    /// </summary>
    public interface ICollidable
    {
        bool IntersectsSphere(SphereCollider other);
       
    }
}

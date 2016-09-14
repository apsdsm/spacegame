using UnityEngine;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// A Physics object can be affected by external physics forces like gravity.
    /// </summary>
    public interface IDestroyable
    {
        /// <summary>
        /// Damage the specified object.
        /// </summary>
        /// <param name="damage">damage object</param>
        void Damage(Damage damage);
    }
}

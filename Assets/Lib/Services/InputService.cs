using UnityEngine;
using SpaceGame.Interfaces;

// specified classes
using MonoBehaviour = UnityEngine.MonoBehaviour;
using Vector2 = UnityEngine.Vector2;

/// <summary>
/// Implementation of the IInputService.
/// </summary>
public class InputService : MonoBehaviour, IInputService  {

    /// <summary>
    /// Get user movement for this update.
    /// </summary>
    /// <returns>Vector3 representing x and y input</returns>
    public Vector2 GetMovement ()
    {
        float horizontal = Input.GetAxis( "Horizontal" );
        float vertical = Input.GetAxis( "Vertical" );
        Vector2 movement = new Vector2( horizontal, vertical );

        return movement;
    }

    /// <summary>
    /// Check to see if weapons were fired this update.
    /// </summary>
    /// <returns>bool if weapons were fired</returns>
    public bool GetWeaponFired ()
    {
        return Input.GetButtonDown( "Fire1" );
    }
}

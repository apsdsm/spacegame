using UnityEngine;
using SpaceGame.Interfaces;
using System;

/// <summary>
/// Takes an IControllableShip object and passes it player input.
/// </summary>
public class PCShipController : MonoBehaviour, IShipController
{
    private IControllableShip ship;

    /// <summary>
    /// Deregister the currently controlled ship (if it matches the ship currently being controlled).
    /// </summary>
    /// <param name="ship"></param>
    public void Deregister (IControllableShip ship)
    {
        if (this.ship == ship) {
            this.ship = null;
        }
    }

    /// <summary>
    /// Registers the ship that should be controlled by this controller.
    /// </summary>
    /// <param name="ship"></param>
    public void Register (IControllableShip ship)
    {
        this.ship = ship;
    }

    /// <summary>
    /// If there is a registered ship, will pass PC input (keyboard and gamepad).
    /// </summary>
    void Update ()
    {
        if (ship == null) {
            return;
        }

        // do forward backwards movement
        ship.AddLongitudinalThrust(Input.GetAxis("Vertical"));

        // do rotational movement
        ship.AddRotationalThrust(Input.GetAxis("Horizontal"));

        // fire weapons
        if (Input.GetButtonDown("Fire1")) {
            ship.Shoot();
        }
    }
}

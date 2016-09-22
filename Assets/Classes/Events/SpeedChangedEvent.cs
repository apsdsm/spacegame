namespace SpaceGame.Events {

    /// <summary>
    /// Called when the speed of the ship changes.
    /// </summary>
    /// <param name="newSpeed">the new speed value</param>
    public delegate void SpeedChangedEvent(float newSpeed);
}

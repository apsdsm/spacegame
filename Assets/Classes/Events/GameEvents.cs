using UnityEngine;
using SpaceGame.Interfaces;
using Fletch;

// keep track of if the game scene has initialized yet
public enum GameSceneState
{
    init,
    update
}

/// <summary>
/// The game scene is loaded when the player starts the game.
/// </summary>
public class GameScene : MonoBehaviour {

    // services
    private IRegistryService registry;

    // factories
    private IEnemyFactory shipFactory;

    // current game scene state
    private GameSceneState state = GameSceneState.init;

	/// <summary>
    /// Initialize the game scene.
    /// </summary>
	void Awake ()
    {
        // resolve service dependencies
        registry = IOC.Resolve<IRegistryService>();
        shipFactory = IOC.Resolve<IEnemyFactory>();
	}
	
	/// <summary>
    /// Tries to Init until the init method returns true, then it will start to
    /// update.
    /// </summary>
	void Update ()
    {

        // What do we do each update

	}
}

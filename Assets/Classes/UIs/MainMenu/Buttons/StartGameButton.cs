using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceGame.UI.MainMenu
{
    /// <summary>
    /// Starts the game.
    /// </summary>
    class StartGameButton : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}

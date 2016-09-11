using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceGame.UI.MainMenu
{
    /// <summary>
    /// Quits the game.
    /// </summary>
    class QuitGameButton : MonoBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

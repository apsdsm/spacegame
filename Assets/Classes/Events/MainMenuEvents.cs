using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuEvents : MonoBehaviour 
{

    public void StartGame()
    {
        Debug.Log("start the game!");
        SceneManager.LoadScene("Game");
    }

    public void EndGame()
    {
        Debug.Log("end the game");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene"); // Loads the Game scene
    }

    public void ButtonEndGame()
    {
        Application.Quit();
    }
}

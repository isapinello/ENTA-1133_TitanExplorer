using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] private UIManager UiSystem;
    //[SerializeField] private InGameHUD GameHud;
    public void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        //UiSystem.ActivateInGameHUD();
        //GameHud.OnStartGame();
    }

    public void ButtonEndGame()
    {
        Application.Quit();
    }
}

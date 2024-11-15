using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIManager UiSystem;
    [SerializeField] private InGameHUD GameHud;
    public void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");

        UiSystem.ActivateInGameHUD();
        GameHud.OnStartGame();
    }
}

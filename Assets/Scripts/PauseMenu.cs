using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PlayerController PlayerPrefab;
    [SerializeField] InGameHUD InGameHUD;
    [SerializeField] UIManager UIManager;

    public void ContinueButton()
    {
        InGameHUD.Unpaused();
        UIManager.ActivateInGameHUD();
        Cursor.visible = false;
    }
    public void ButtonEndGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}

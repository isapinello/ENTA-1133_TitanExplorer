using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Layouts;
    [SerializeField] private CombatRoomBase combatRoom;
    [SerializeField] private PlayerController playerController;
    private enum MenuLayouts
    {
        InGame = 0,
        Pause = 1,
        Combat = 2,
        GameOver = 3,
        Treasure = 4,
        GotRescued = 5
    }
    private void Start()
    {
        ActivateInGameHUD();
    }
    public void ButtonRestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    private void SetLayout(MenuLayouts layout)
    {
        for(int i = 0; i < Layouts.Length; i++)
        {
            Layouts[i].SetActive((int)layout == i);
        }
    }
    public void ActivateInGameHUD()
    {
        playerController.SetMovementEnabled(true);
        SetLayout(MenuLayouts.InGame);
    }
    public void ShowPauseMenu()
    {
        playerController.SetMovementEnabled(false);
        SetLayout(MenuLayouts.Pause);
    }
    public void ShowGameOver()
    {
        playerController.SetMovementEnabled(false);
        SetLayout(MenuLayouts.GameOver);
    }
    public void ShowRescue()
    {
        playerController.SetMovementEnabled(false);
        SetLayout(MenuLayouts.GotRescued);
    }
    public void ActivateCombat()
    {
        playerController.SetMovementEnabled(false);
        SetLayout(MenuLayouts.Combat);
    }
    public void ActivateTreasure()
    {
        playerController.SetMovementEnabled(false);
        SetLayout(MenuLayouts.Treasure);
    }
}

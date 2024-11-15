using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Layouts;

    private enum MenuLayouts
    {
        Main = 0,
        InGame = 1,
        Pause = 2
    }
    private void Start()
    {
        OpenMainMenu();
    }
    private void SetLayout(MenuLayouts layout)
    {
        for(int i = 0; i < Layouts.Length; i++)
        {
            Layouts[i].SetActive((int)layout == i);
        }
    }
    public void OpenMainMenu()
    {
        SetLayout(MenuLayouts.Main);
    }
    public void ActivateInGameHUD()
    {
        SetLayout(MenuLayouts.InGame);
    }
    public void ShowPauseMenu()
    {
        SetLayout(MenuLayouts.Pause);
    }
}

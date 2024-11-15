using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Layouts;

    private enum MenuLayouts
    {
        InGame = 0,
        Pause = 1
    }
    private void Start()
    {
        ActivateInGameHUD();
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
        SetLayout(MenuLayouts.InGame);
    }
    public void ShowPauseMenu()
    {
        SetLayout(MenuLayouts.Pause);
    }
}

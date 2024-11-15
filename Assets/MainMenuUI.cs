using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject[] Layout;
    private enum MenuLayouts
    {
        Main = 0
    }
    private void Start()
    {
        OpenMainMenu();
    }
    private void SetLayout(MenuLayouts layout)
    {
        for (int i = 0; i < Layout.Length; i++)
        {
            Layout[i].SetActive((int)layout == i);
        }
    }
    public void OpenMainMenu()
    {
        SetLayout(MenuLayouts.Main);
    }
}

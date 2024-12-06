using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject[] Layout;
    private enum MenuLayouts
    {
        Main = 0,
        Intro1 = 1,
        Intro2 = 2,
        Logo = 3,
        Controls = 4
    }
    private void Start()
    {
        OpenLogo();
        Cursor.visible = true;
    }
    private void SetLayout(MenuLayouts layout)
    {
        for (int i = 0; i < Layout.Length; i++)
        {
            Layout[i].SetActive((int)layout == i);
        }
    }

    // Bellow is the logic to the "cut-scenes" activation
    public void OpenLogo()
    {
        SetLayout(MenuLayouts.Logo);
    }
    public void OpenControls()
    {
        SetLayout(MenuLayouts.Controls);
    }
    public void OpenIntro1()
    {
        SetLayout(MenuLayouts.Intro1);
    }
    public void OpenIntro2()
    {
        SetLayout(MenuLayouts.Intro2);
    }
    public void OpenMainMenu()
    {
        SetLayout(MenuLayouts.Main);
    }
}

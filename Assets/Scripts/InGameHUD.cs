using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameHUD : MonoBehaviour
{
    [SerializeField] Text Timer;
    [SerializeField] Image HealthBar;
    [SerializeField] UIManager Ui;

    public bool _gamePaused = true;
    private float _timer = 120f;

    public void OnStartGame()
    {
        _gamePaused = false;
        HealthBar.fillAmount = 1;
    }
    public void Unpaused()
    {
        _gamePaused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseGame();
        }
        if (_gamePaused)
        {
            return;
        }
        _timer -= Time.deltaTime;
        Timer.text = $"{_timer,0:0.000}";

        if (_timer == 0f)
        {
            Debug.Log("You lost");
        }
    }

    public void OnPauseGame()
    {
        _gamePaused = true;
        Ui.ShowPauseMenu();
    }
    public void OnCombatGame()
    {
        Cursor.visible = true;
        _gamePaused = true;
        Ui.ActivateCombat();
    }
}

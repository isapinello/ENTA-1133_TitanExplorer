using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameHUD : MonoBehaviour
{
    [SerializeField] Text Timer;
    [SerializeField] Image HealthBar;

    private bool _gamePaused = true;
    private float _timer = 120f;

    public void OnStartGame()
    {
        _gamePaused = false;
        HealthBar.fillAmount = 1;
    }
    private void Update()
    {
        if (_gamePaused)
        {
            return;
        }
        _timer -= Time.deltaTime;
        Timer.text = $"{_timer,0:0.000}";
    }

    public void OnPauseGame()
    {
        _gamePaused = true;
        
    }
}

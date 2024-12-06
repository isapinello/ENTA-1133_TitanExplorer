using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameHUD : MonoBehaviour
{
    [SerializeField] Text Timer;
    [SerializeField] Text LifeCores;
    [SerializeField] Image HealthBar;
    [SerializeField] UIManager Ui;
    [SerializeField] PlayerManager playerManager; // Reference to the PlayerManager

    public bool _gamePaused = true;
    private float _timer = 20f;

    public void OnStartGame()
    {
        _gamePaused = false;
        HealthBar.fillAmount = 1; // Full health bar at start
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

        if (_gamePaused) return;

        _timer -= Time.deltaTime;
        Timer.text = $"{_timer:0.000}";

        if (_timer <= 0f)
        {
            Debug.Log("You got rescued");
            _timer = 0f;
        }
        LifeCores.text = $"{playerManager.LifeCores}";
        UpdateHealthBar();

        if (_timer == 0f)
        {
            Cursor.visible = true;
            Ui.ShowRescue();
        }
    }

    public void UpdateHealthBar()
    {
        if (playerManager == null)
        {
            Debug.LogWarning("PlayerManager not assigned!");
            return;
        }

        // Calculate health percentage
        float healthPercentage = (float)playerManager.GetCurrentHealth() / playerManager.GetMaxHealth();
        HealthBar.fillAmount = healthPercentage; // Update the health bar
    }

    public void OnPauseGame()
    {
        Cursor.visible = true;
        _gamePaused = true;
        Ui.ShowPauseMenu();
    }

    public void OnCombatGame()
    {
        Cursor.visible = true;
        _gamePaused = true;
        Ui.ActivateCombat();
    }

    public void OnTreasureRoom()
    {
        Cursor.visible = true;
        _gamePaused = true;
        Ui.ActivateTreasure();
    }

    public void OnButtonYesPressed()
    {
        playerManager.AddLifeCore(1);
        _gamePaused = false;
        Ui.ActivateInGameHUD();
        Cursor.visible = false;
    }
}

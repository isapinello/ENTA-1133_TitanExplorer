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
        if (Input.GetKeyDown(KeyCode.Escape)) // Press esc to pause game
        {
            OnPauseGame();
        }

        if (_gamePaused) return;

        _timer -= Time.deltaTime;
        Timer.text = $"{_timer:0.000}"; // Timer goes counter-clock
        LifeCores.text = $"{playerManager.LifeCores}"; // Shows how many life cores the player collected
        UpdateHealthBar();

        if (_timer <= 0) // Player wins the game and the timer doesn't go bellow 0
        {
            _timer = 0f;
            Cursor.visible = true;
            Ui.ShowRescue();
        }
    }

    public void UpdateHealthBar()
    {
        if (playerManager == null)
        {
            Debug.LogWarning("PlayerManager not assigned!"); // Debug to warn of the missing serialized field
            return;
        }

        // Calculate health percentage
        float healthPercentage = (float)playerManager.GetCurrentHealth() / playerManager.GetMaxHealth();
        HealthBar.fillAmount = healthPercentage; // Update the health bar
    }

    // All the bellow ensure the timer doesn't run outside of the InGameHUD and the cursor is properly visible or not
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

    public void OnButtonYesPressed() // When inside a treasure room press yes to collect 1 life core
    {
        playerManager.AddLifeCore(1);
        _gamePaused = false;
        Ui.ActivateInGameHUD();
        Cursor.visible = false;
    }
}

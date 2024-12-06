using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Maximum health of the player
    [SerializeField] private int lifeCores = 0;

    public int currentHealth;
    public int LifeCores => lifeCores;

    private void Start()
    {
        currentHealth = maxHealth; // Initialize player's health
        Debug.Log($"Player starts with {currentHealth} HP.");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        Debug.Log($"Player takes {damage} damage. Current health: {currentHealth}");
        UpdateHealthUI();

        if (currentHealth == 0)
        {
            OnPlayerDeath();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        Debug.Log($"Player heals {amount} HP. Current health: {currentHealth}");
        UpdateHealthUI();
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    private void UpdateHealthUI()
    {
        // Update the health bar or other UI elements
        Debug.Log("Player health UI updated.");
    }

    private void OnPlayerDeath()
    {
        Debug.Log("Player has died!");
        // Trigger game over sequence or reload last checkpoint
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public void AddLifeCore(int amount)
    {
        lifeCores += amount;
        Debug.Log($"Player gained {amount} Life Core(s). Total: {lifeCores}");
    }

    public bool UseLifeCore(int healAmount)
    {
        if (lifeCores > 0 && currentHealth < maxHealth)
        {
            lifeCores--;

            // Ensure currentHealth does not exceed maxHealth
            currentHealth += healAmount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            Debug.Log($"Player used a Life Core. Healed for {healAmount} HP. Current Health: {currentHealth}/{maxHealth}. Remaining Life Cores: {lifeCores}");
            return true;
        }
        Debug.Log("No Life Cores left or health is already full.");
        return false;
    }
}
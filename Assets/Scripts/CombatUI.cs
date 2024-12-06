using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class CombatUI : MonoBehaviour
{
    [SerializeField] InGameHUD InGameHUD;
    [SerializeField] UIManager UIManager;
    [SerializeField] public TMP_Text enemyNameText;
    [SerializeField] public TMP_Text enemyHPText;
    [SerializeField] public TMP_Text playerHPText;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Image enemyImage;
    [SerializeField] private GameObject weaponsMenu;
    private void Start()
    {
        weaponsMenu.SetActive(false); // So the Weapons don't cover the other buttons when combat starts
    }
    public void FightButton()
    {
        weaponsMenu.SetActive(true);
    }
    public void DisplayEnemy(Decomposer enemy) // Randomly selects an enemy, changing the name, HP, and image on the screen
    {
        enemyNameText.text = enemy.Name;
        enemyHPText.text = $"HP: {enemy.HP}";
        enemyImage.sprite = enemy.GetUIImage();
        Debug.Log($"Displaying enemy: {enemy.Name} with {enemy.HP} HP.");
    }
    private void Update()
    {
        playerHPText.text = $"HP: {playerManager.currentHealth}"; // Shows player's HP even inside the Combat 
    }
    public void UpdateEnemyHP(int hp)
    {
        enemyHPText.text = $"HP: {hp}";
        Debug.Log($"Enemy HP updated to: {hp}");
    }

    public void UpdatePlayerHealth(int damage)
    {
        playerManager.TakeDamage(damage);
        Debug.Log($"Player takes {damage} damage.");
    }

    public bool IsPlayerDead()
    {
        return playerManager.IsDead();
    }

    public void EndCombat(bool playerWon)
    {
        if (playerWon)
        {
            playerManager.AddLifeCore(25); // Player receives more life cores when killing an enemy
            InGameHUD.Unpaused();
            UIManager.ActivateInGameHUD();
            Cursor.visible = false;
        }
        else
        {
            UIManager.ShowGameOver();
        }
    }
    public void UseItemButton()
    {
        playerManager.UseLifeCore(10); // Heals the player
    }
    public void FleeButton()
    {
        InGameHUD.Unpaused();
        UIManager.ActivateInGameHUD();
        Cursor.visible = false;
    }
}
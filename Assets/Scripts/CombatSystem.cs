using UnityEngine;
using System.Collections.Generic;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> decomposerPrefabs; // Drag-and-drop enemy prefabs
    [SerializeField] private CombatUI combatUI; // Reference to Combat UI
    //[SerializeField] private PlayerController playerController;

    private Decomposer currentEnemy;

    public void StartCombat()
    {
        //playerController.DisableMovement();
        if (decomposerPrefabs == null || decomposerPrefabs.Count == 0)
        {
            Debug.LogError("No Decomposer prefabs assigned to CombatSystem!");
            return;
        }

        // Select a random prefab and instantiate it to get the Decomposer
        GameObject selectedPrefab = decomposerPrefabs[Random.Range(0, decomposerPrefabs.Count)];
        currentEnemy = Instantiate(selectedPrefab).GetComponent<Decomposer>();

        if (currentEnemy == null)
        {
            Debug.LogError("Selected prefab does not have a Decomposer component!");
            return;
        }
        if (currentEnemy.Name == "Bonecrusher")
        {
            Debug.Log("The enemy is Bonecrusher!");
        }
        // Send enemy data to the UI
        combatUI.DisplayEnemy(currentEnemy);
    }

    public void PlayerSelectWeapon(Weapon selectedWeapon)
    {
        Debug.Log($"Player selected weapon: {selectedWeapon.Name} with {selectedWeapon.DiceSides}-sided dice!");
        ExecuteCombatTurn(selectedWeapon);
    }

    private void ExecuteCombatTurn(Weapon playerWeapon)
    {
        // Player's attack
        int playerRoll = Random.Range(1, playerWeapon.DiceSides + 1);
        Debug.Log($"Player rolled {playerRoll}!");

        currentEnemy.TakeDamage(playerRoll);
        combatUI.UpdateEnemyHP(currentEnemy.HP);

        if (currentEnemy.HP <= 0)
        {
            EndCombat(true);
            return;
        }

        // Enemy's attack
        int enemyRoll = currentEnemy.RollDice();
        Debug.Log($"Enemy rolled {enemyRoll}!");

        combatUI.UpdatePlayerHealth(enemyRoll);

        if (combatUI.IsPlayerDead())
        {
            EndCombat(false);
        }
    }

    private void EndCombat(bool playerWon)
    {
        if (playerWon)
        {
            Debug.Log("Player won the combat!");
        }
        else
        {
            Debug.Log("Player lost the combat...");
        }

        combatUI.EndCombat(playerWon); // Ensures that the UI also ends the combat
        if (currentEnemy != null) Destroy(currentEnemy.gameObject); // Clean up enemy instance
    }
}
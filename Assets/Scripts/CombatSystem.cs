using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;
    private List<Decomposer> _enemies; // List to hold multiple enemies

    public CombatSystem(PlayerManager player)
    {
        _player = player;
        _enemies = GetRandomEnemies(); // Get a random set of enemies when combat starts
    }
    // Method to randomly select multiple enemies
    private List<Decomposer> GetRandomEnemies()
    {
        int enemyCount = Random.Range(1, 4); // Randomly choose 1 to 3 enemies
        var enemies = new List<Decomposer>();

        for (int i = 0; i < enemyCount; i++)
        {
            enemies.Add(GetRandomEnemy());
        }
        return enemies;
    }
    // Method to randomly select an enemy
    private Decomposer GetRandomEnemy()
    {
        int enemyType = Random.Range(1, 4);

        return enemyType switch
        {
            1 => new Decomposer.SmallLarvae(),
            2 => new Decomposer.RoundWorm(),
            3 => new Decomposer.BoneCrusher(),
            _ => new Decomposer.SmallLarvae() // Fallback in case something goes wrong
        };
    }
    public void StartCombat()
    {
        /*if (_player?.CurrentWeapon == null)
        {
            Debug.Log("Combat cannot start: PlayerManager or CurrentWeapon is missing!");
            return;
        }

        int playerRoll = _player.RollDice();
        Debug.Log($"Player rolled: {playerRoll} using {_player.CurrentWeapon.Name}");*/
        while (_player.HP > 0 && _enemies.Any(e => e.HP > 0))
        {
            foreach (var enemy in _enemies)
            {
                int playerRoll = _player.RollDice();
                int enemyRoll = enemy.RollDice();
                Debug.Log($"You rolled: {playerRoll}, {enemy.Name} rolled: {enemyRoll}");

                if (playerRoll > enemyRoll)
                {
                    int damage = playerRoll - enemyRoll;
                    enemy.TakeDamage(damage);
                    Debug.Log($"You dealt {damage} damage to {enemy.Name}! {enemy.Name} HP: {enemy.HP}");
                }
                else if (enemyRoll > playerRoll)
                {
                    int damage = enemyRoll - playerRoll;
                    _player.TakeDamage(damage);
                    Debug.Log($"{enemy.Name} dealt {damage} damage to you! Your HP: {_player.HP}");
                }
                else
                {
                    Debug.Log("sudgfhsfghj");
                }

                if (_player.HP <= 0)
                {
                    return;
                }

                if (enemy.HP <= 0)
                {
                    Debug.Log("sudgfhsfghj");
                }
            }
        }
    }
}

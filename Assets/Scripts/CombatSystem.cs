using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;

    public void StartCombat()
    {
        if (_player?.CurrentWeapon == null)
        {
            Debug.Log("Combat cannot start: PlayerManager or CurrentWeapon is missing!");
            return;
        }

        int playerRoll = _player.RollDice();
        Debug.Log($"Player rolled: {playerRoll} using {_player.CurrentWeapon.Name}");
    }
}

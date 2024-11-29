using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour
{
    [SerializeField] InGameHUD InGameHUD;
    [SerializeField] UIManager UIManager;
    private PlayerManager _player;
    private CombatSystem combatSystem;

    [System.Obsolete]
    private void Start()
    {
        combatSystem = FindObjectOfType<CombatSystem>();
        combatSystem.StartCombat(); // Start combat with possible multiple enemies
    }
    public void ItemsButton()
    {

    }
    public void WeaponsButton()
    {

    }
    public void FleeButton()
    {
        InGameHUD.Unpaused();
        UIManager.ActivateInGameHUD();
        Cursor.visible = false;
    }
}

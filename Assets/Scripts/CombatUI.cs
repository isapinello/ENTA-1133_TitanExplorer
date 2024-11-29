using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour
{
    [SerializeField] InGameHUD InGameHUD;
    [SerializeField] UIManager UIManager;
    private PlayerManager _player;
    private CombatSystem combatSystem;
    public void FleeButton()
    {
        InGameHUD.Unpaused();
        UIManager.ActivateInGameHUD();
        Cursor.visible = false;
    }
}

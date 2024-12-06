using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoomBase : RoomBase
{
    private InGameHUD _inGameHUD;
    private CombatSystem _startCombat;

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        _inGameHUD = FindObjectOfType<InGameHUD>();
        _startCombat = FindObjectOfType<CombatSystem>();
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered combat room");
            _inGameHUD.OnCombatGame();
            _startCombat.StartCombat();
        }
    }
    public override void OnRoomEntered()
    {
        Debug.Log("Combat Room Entered");
    }

    public override void OnRoomExited()
    {
        Debug.Log("Combat Room Exited");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoomBase : RoomBase
{
    private InGameHUD _inGameHUD;

    private void Start()
    {
        _inGameHUD = FindObjectOfType<InGameHUD>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered combat room");
            _inGameHUD.OnCombatGame();
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

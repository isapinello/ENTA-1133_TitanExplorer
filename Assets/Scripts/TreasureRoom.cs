using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : RoomBase
{
    private InGameHUD _inGameHUD;

    [System.Obsolete]
    private void OnTriggerEnter(Collider other) // Every time you enter or re-enter the treasure room you receive a life core
    {
        _inGameHUD = FindObjectOfType<InGameHUD>();

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered treasure room");
            _inGameHUD.OnTreasureRoom();
        }
    }
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }
    public override void OnRoomEntered()
    {
        Debug.Log("Treasure Room Entered");
    }
    public override void OnRoomExited()
    {
        Debug.Log("Treasure Room Exited");
    }
}

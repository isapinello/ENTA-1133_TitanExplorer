using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRoom : RoomBase
{
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Just a Normal Room");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private RoomBase[] RoomPrefabs; // Prefabs of the specific rooms
    [SerializeField] private float RoomSize = 3.2f; // Gap between rooms
    private GameManager _manager;

    private const int MapSize = 4;
    readonly Dictionary<Vector2, RoomBase> _rooms = new();
    public Dictionary<Vector2, RoomBase> Rooms => _rooms;

    public void CreateMap(GameManager manager)
    {
        _manager = manager;
        for (int x = 0; x < MapSize; x++)
        {
            for (int z = 0; z < MapSize; z++)
            {
                if (z == 3 && x == 0 || z == 3 && x == 3)
                {
                    continue;
                }

                Vector2 coords = new(x, z);

                var roomInstance = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)], transform);

                roomInstance.SetRoomLocation(new Vector2(coords.x*RoomSize, coords.y*RoomSize));

                _rooms.Add(coords, roomInstance);
                Debug.Log(coords + "    " + roomInstance.name);
            }
        }
    


        foreach (var roomByCoordinate in _rooms)
        {
            Debug.Log(roomByCoordinate.Key);
            RoomBase northRoom = FindRoom(roomByCoordinate.Key, Direction.North);
            RoomBase eastRoom = FindRoom(roomByCoordinate.Key, Direction.East);
            RoomBase southRoom = FindRoom(roomByCoordinate.Key, Direction.South);
            RoomBase westRoom = FindRoom(roomByCoordinate.Key, Direction.West);
           
            roomByCoordinate.Value.SetRooms(northRoom, eastRoom, southRoom, westRoom);
        }
    }

    private RoomBase FindRoom(Vector2 currentRoom, Direction direction)
    {
        RoomBase room = null;
        Vector2 nextRoomCoordinates = new Vector2();
        switch (direction)
        {
            case Direction.North:
                // Determine North Room
                nextRoomCoordinates = currentRoom + (new Vector2(0, 1));
              //  Debug.Log("NORTH: " + nextRoomCoordinates);
                break;
            case Direction.East:
                // east
                nextRoomCoordinates = currentRoom + (new Vector2 (1, 0));
                break;
            case Direction.South:
                // south
                nextRoomCoordinates = currentRoom + (new Vector2(0, - 1));
                //    Debug.Log("SOUTH: " + nextRoomCoordinates);
                break;
            case Direction.West:
                // west
                nextRoomCoordinates = currentRoom + (new Vector2(- 1, 0));
                break;
        }
        if (_rooms.TryGetValue(nextRoomCoordinates, out var nextRoom))
        { 
            Debug.Log(nextRoom.name);
            room = nextRoom;
        }
        return room;
    }
}
public enum Direction
{
    North,
    East,
    South,
    West
}

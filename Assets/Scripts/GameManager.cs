using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
   // [SerializeField] private int mapSize = 5;
    [SerializeField] private MapManager GameMapPrefab;
    [SerializeField] private PlayerController PlayerPrefab;
   // public int MapSize => mapSize;
    private PlayerController _playerController;
    private MapManager _gameMap;

    private void Start()
    {
        transform.position = Vector3.zero;
        SetupMap();
        SpawnPlayer();
    }
    private void SetupMap()
    {
        Debug.Log("GameManager SetupMap Begins");
        // create an instance of the map manager
        _gameMap = Instantiate(GameMapPrefab, transform);
        _gameMap.transform.position = Vector3.zero;
        // create the map
        _gameMap.CreateMap();
        Debug.Log("GameManager Setup Complete");
    }
    private void SpawnPlayer()
    {
        Debug.Log("GameManager SpawnPlayer Begins");

        // Pick a random starting room - after the map has been created
        if (_gameMap.Rooms.Count == 0)
        {
            Debug.LogError("No rooms available in the map to spawn the player!");
            return;
        }

        // Select a random room to spawn the player
        var randomRoom = _gameMap.Rooms.ElementAt(Random.Range(0, _gameMap.Rooms.Count));
        Vector2 roomCoords = randomRoom.Key;
        RoomBase roomInstance = randomRoom.Value;

        // Instantiate the player and set their position to the room's location
        _playerController = Instantiate(PlayerPrefab, transform);
        _playerController.transform.position = new Vector3(roomCoords.x, 0, roomCoords.y);

        Debug.Log($"Player spawned at room coordinates: {roomCoords}");
    }
}
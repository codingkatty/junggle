using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InitGame : MonoBehaviour
{
    [SerializeField]
    private AbstractDungeonGenerator dungeonGenerator = null;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Tilemap wallTile;

    private static Dictionary<Vector2Int, HashSet<Vector2Int>> rooms =
        new Dictionary<Vector2Int, HashSet<Vector2Int>>();

    private HashSet<Vector2Int> floorPositions;

    public static void SaveRoom(Vector2Int roomPosition, HashSet<Vector2Int> roomFloor)
    {
        rooms[roomPosition] = new HashSet<Vector2Int>(roomFloor);
    }

    public static void ClearRooms()
    {
        rooms.Clear();
    }

    void Start()
    {
        ClearRooms();
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        dungeonGenerator.GenerateDungeon();

        SetupCollision();
        SpawnPlayer();
    }

    private void SetupCollision()
    {
        // wtf ahh
        TilemapCollider2D wallCollider = wallTile.GetComponent<TilemapCollider2D>();
        if (wallCollider == null)
        {
            wallCollider = wallTile.gameObject.AddComponent<TilemapCollider2D>();
        }
    }

    private void SpawnPlayer()
    {
        int roomIndex = Random.Range(0, rooms.Count);
        KeyValuePair<Vector2Int, HashSet<Vector2Int>> room = rooms.ElementAt(roomIndex);
        List<Vector2Int> roomFloors = new List<Vector2Int>(room.Value);

        Vector2Int spawnPos = roomFloors[Random.Range(0, roomFloors.Count)];
        Vector3 worldPos = new Vector3(spawnPos.x + 0.5f, spawnPos.y + 0.5f, 0);
        player.transform.position = worldPos;
    }
}

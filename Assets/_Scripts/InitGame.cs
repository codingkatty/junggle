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

    private HashSet<Vector2Int> floorPositions;

    void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        dungeonGenerator.GenerateDungeon();

        SimpleRandomWalkDungeonGenerator walkGenerator =
            dungeonGenerator as SimpleRandomWalkDungeonGenerator;
        System.Reflection.MethodInfo runRandomWalkMethod =
            typeof(SimpleRandomWalkDungeonGenerator).GetMethod(
                "RunRandomWalk",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            );

        floorPositions = (HashSet<Vector2Int>)runRandomWalkMethod.Invoke(walkGenerator, null);

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
        PlayerMovement player = FindFirstObjectByType<PlayerMovement>();
        Vector2Int randomPos = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        Vector3 worldPos = new Vector3(randomPos.x + 0.5f, randomPos.y + 0.5f, 0);
        player.transform.position = worldPos;
    }
}

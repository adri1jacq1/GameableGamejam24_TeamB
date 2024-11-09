using UnityEngine;
using System.Collections.Generic;

public class RandomTileGenerator : MonoBehaviour
{
    public GameObject streetTile; // Prefab for street tile (0.5x1)
    public GameObject[] buildingTiles; // Prefabs for building tiles (1x1, 2.5x1, 1x0.5, etc.)
    public int gridWidth = 10;  
    public int gridHeight = 10; 
    public float cellSize = 1.0f;  

    private bool[,] gridOccupied;  

    void Start()
    {
        gridOccupied = new bool[gridWidth, gridHeight];
        GenerateScene();
    }

    void GenerateScene()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                if (!gridOccupied[x, y])  
                {
                    PlaceRandomTile(x, y);
                }
            }
        }
    }

    void PlaceRandomTile(int x, int y)
    {
        // Randomly decide if this is a street or building tile
        bool isStreet = Random.value > 0.7f; // Adjust for desired street/building ratio
        GameObject tilePrefab = isStreet ? streetTile : buildingTiles[Random.Range(0, buildingTiles.Length)];

        Vector2 tileSize = GetTileSize(tilePrefab); // Determine the size of the tile in grid units
        if (CanPlaceTile(x, y, tileSize))
        {
            Vector3 position = new Vector3(x * cellSize, y * cellSize, 0);
            Instantiate(tilePrefab, position, Quaternion.identity);
            MarkGridOccupied(x, y, tileSize); // Mark cells as occupied
        }
    }

    Vector2 GetTileSize(GameObject tile)
    {
        // Here you can define sizes manually or retrieve from tile properties
        if (tile == streetTile) return new Vector2(0.5f, 1); // Street tile size
        // Example: Assuming the sizes are based on prefab names or tags
        if (tile.name.Contains("1x1")) return new Vector2(1, 1);
        if (tile.name.Contains("2.5x1")) return new Vector2(2.5f, 1);
        if (tile.name.Contains("1x0.5")) return new Vector2(1, 0.5f);
        if (tile.name.Contains("2.5x2.5")) return new Vector2(2.5f, 2.5f);

        return Vector2.one; // Default to 1x1 if not specified
    }

    bool CanPlaceTile(int startX, int startY, Vector2 tileSize)
    {
        // Check if the tile fits within grid bounds and cells are unoccupied
        int endX = startX + Mathf.CeilToInt(tileSize.x) - 1;
        int endY = startY + Mathf.CeilToInt(tileSize.y) - 1;
        if (endX >= gridWidth || endY >= gridHeight) return false;

        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                if (gridOccupied[x, y]) return false;
            }
        }
        return true;
    }

    void MarkGridOccupied(int startX, int startY, Vector2 tileSize)
    {
        // Mark cells occupied by the placed tile
        int endX = startX + Mathf.CeilToInt(tileSize.x) - 1;
        int endY = startY + Mathf.CeilToInt(tileSize.y) - 1;
        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                gridOccupied[x, y] = true;
            }
        }
    }
}

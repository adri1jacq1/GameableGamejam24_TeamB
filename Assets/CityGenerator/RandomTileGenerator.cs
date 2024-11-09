using UnityEngine;

public class RandomTileGenerator : MonoBehaviour
{
    public GameObject streetTile; // Prefab for street tile (0.5x1)
    public GameObject[] buildingTiles; // Prefabs for building tiles (1x1, 2.5x1, etc.)
    public int gridWidth = 10; // Width of the grid
    public int gridHeight = 10; // Height of the grid
    public float tileSize = 1.0f; // Adjust if tiles are not uniformly scaled

    void Start()
    {
        GenerateScene();
    }

    void GenerateScene()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                PlaceRandomTile(x, y);
            }
        }
    }

    void PlaceRandomTile(int x, int y)
    {
        // Randomly decide if this is a street or building tile
        bool isStreet = Random.value > 0.7f; // Adjust the threshold for more or fewer streets

        GameObject tilePrefab = isStreet ? streetTile : buildingTiles[Random.Range(0, buildingTiles.Length)];
        Vector3 position = new Vector3(x * tileSize, y * tileSize, 0);
        Instantiate(tilePrefab, position, Quaternion.identity);
    }
}

using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs; // Array of tile prefabs for variety
    public int width = 10;
    public int height = 10;
    public float tileSpacing = 1.0f;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length)],
                                              new Vector2(x * tileSpacing, y * tileSpacing),
                                              Quaternion.identity);
                tile.transform.parent = transform;
            }
        }
    }
}

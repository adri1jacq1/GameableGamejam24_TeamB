using UnityEngine;

public class AreaGenerator : MonoBehaviour
{
    public GameObject tilePrefab; // Prefab of the tile to generate
    public int width = 5;
    public int height = 5;
    public float tileSpacing = 1.0f; // Distance between tiles
    private bool hasGenerated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("creatting");
        // Check if the camera entered the trigger
        if (other.CompareTag("MainCamera"))
        {
            if (!hasGenerated)
            {
                GenerateTiles();
                hasGenerated = true; // Prevents re-triggering
            }
        }
    }

    void GenerateTiles()
    {
        // Generate a grid of tiles in the specified area
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 spawnPosition = (Vector2)transform.position +
                                        new Vector2(x * tileSpacing, y * tileSpacing);
                Instantiate(tilePrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}

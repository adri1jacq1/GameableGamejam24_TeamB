using UnityEngine;
using System.Collections.Generic;

public class CityBuilder : MonoBehaviour
{
    public GameObject horizontalStreetPrefab;   // Prefab for horizontal streets
    public GameObject verticalStreetPrefab;     // Prefab for vertical streets
    public GameObject buildingPrefab;           // Prefab for buildings
    public GameObject peoplePrefab;             // Prefab for people
    public SpriteRenderer areaSprite;           // SpriteRenderer for defining area bounds
    public float streetSpacing = 3f;            // Minimum spacing between streets
    public float proximityToStreet = 1.5f;      // Distance range for placing buildings and people near streets
    public int streetCount = 10;                // Number of streets to place
    public int buildingCount = 5;               // Number of buildings to place
    public int peopleCount = 10;                // Number of people to place

    private List<Vector2> streetPositions = new List<Vector2>();
    private Vector2 areaMin;
    private Vector2 areaMax;

    void Start()
    {
        // Calculate area bounds based on the sprite dimensions
        areaMin = (Vector2)areaSprite.transform.position - (areaSprite.size / 2) * areaSprite.transform.lossyScale;
        areaMax = (Vector2)areaSprite.transform.position + (areaSprite.size / 2) * areaSprite.transform.lossyScale;
         
        PlaceStreets();

         
        PlaceBuildings();
        PlacePeople();
    }

    void PlaceStreets()
    {
        int maxAttempts = 100;
        bool isHorizontal = true;  

        for (int i = 0; i < streetCount; i++)
        {
            bool positionFound = false;

            while (!positionFound && maxAttempts > 0)
            {
                Vector2 streetPosition;

                if (isHorizontal)
                { 
                    float yPosition = Mathf.Round(Random.Range(areaMin.y, areaMax.y) / streetSpacing) * streetSpacing;
                    float xPosition = Random.Range(areaMin.x, areaMax.x);
                    streetPosition = new Vector2(xPosition, yPosition);
                }
                else
                { 
                    float xPosition = Mathf.Round(Random.Range(areaMin.x, areaMax.x) / streetSpacing) * streetSpacing;
                    float yPosition = Random.Range(areaMin.y, areaMax.y);
                    streetPosition = new Vector2(xPosition, yPosition);
                }
                 
                bool isFarEnough = true;
                foreach (Vector2 existingStreetPos in streetPositions)
                {
                    if (Vector2.Distance(streetPosition, existingStreetPos) < streetSpacing)
                    {
                        isFarEnough = false;
                        break;
                    }
                }

                if (isFarEnough)
                { 
                    if (isHorizontal)
                        Instantiate(horizontalStreetPrefab, streetPosition, Quaternion.identity);
                    else
                        Instantiate(verticalStreetPrefab, streetPosition, Quaternion.Euler(0, 0, 90));

                    streetPositions.Add(streetPosition);
                    positionFound = true;

                    // Toggle orientation for the next street
                    isHorizontal = !isHorizontal;
                }

                maxAttempts--;
            }
        }
    }

    void PlaceBuildings()
    {
        for (int i = 0; i < buildingCount; i++)
        { 
            Vector2 streetPos = streetPositions[Random.Range(0, streetPositions.Count)];
            Vector2 buildingPosition = streetPos + (Vector2)Random.insideUnitCircle * proximityToStreet;
             
            buildingPosition = new Vector2(
                Mathf.Clamp(buildingPosition.x, areaMin.x, areaMax.x),
                Mathf.Clamp(buildingPosition.y, areaMin.y, areaMax.y)
            );

            // Place building with random rotation
            Instantiate(buildingPrefab, buildingPosition, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }

    void PlacePeople()
    {
        for (int i = 0; i < peopleCount; i++)
        { 
            Vector2 streetPos = streetPositions[Random.Range(0, streetPositions.Count)];
            Vector2 peoplePosition = streetPos + (Vector2)Random.insideUnitCircle * proximityToStreet;

            // Clamp position to stay within the area bounds
            peoplePosition = new Vector2(
                Mathf.Clamp(peoplePosition.x, areaMin.x, areaMax.x),
                Mathf.Clamp(peoplePosition.y, areaMin.y, areaMax.y)
            );

            // Place person with random rotation
            Instantiate(peoplePrefab, peoplePosition, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }
}

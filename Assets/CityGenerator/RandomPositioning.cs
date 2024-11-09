using System.Collections.Generic;
using UnityEngine;

public class RandomPositioning : MonoBehaviour
{
    List<GameObject> listCreated;
    public GameObject peoplePrefab;        
    public GameObject buildingPrefab;      
    public SpriteRenderer areaSprite;      
    public float spawnRadius = 1f;         

    private Vector2 areaMin;              
    private Vector2 areaMax;

    public SpriteRenderer citySprite;
    private Vector2 cityMax;
    private Vector2 cityMin;
    private Vector2 buildingPosition;
    public int numPeople,numShops;

    void Start()
    { 
        areaMin = (Vector2)areaSprite.transform.position - (areaSprite.size / 2) * areaSprite.transform.lossyScale;
        areaMax = (Vector2)areaSprite.transform.position + (areaSprite.size / 2) * areaSprite.transform.lossyScale;
         

        cityMax = (Vector2)citySprite.transform.position - (citySprite.size / 2) * citySprite.transform.lossyScale;
        areaMin = (Vector2)citySprite.transform.position + (citySprite.size / 2) * citySprite.transform.lossyScale;
        for (int i = 0; i < numShops; i++)
        {
            buildingPosition = GetRandomPosition();
            Instantiate(buildingPrefab, buildingPosition, Quaternion.identity);

        }
         
        for (int i = 0; i < numPeople; ++i)
        {

            Vector2 peoplePosition = GetRandomPosition();
            Instantiate(peoplePrefab, peoplePosition, Quaternion.identity);
        }
    }

    Vector2 GetRandomPosition()
    {
        Vector2 randomPosition;
        bool positionValid = false;
        int maxAttempts = 100;  

        while (!positionValid && maxAttempts > 0)
        {
            randomPosition = new Vector2(
                Random.Range(areaMin.x, areaMax.x),
                Random.Range(areaMin.y, areaMax.y)
            );
             
            if (Vector2.Distance(randomPosition, buildingPosition) >= spawnRadius)
            {
                positionValid = true;
                return randomPosition;
            }

            maxAttempts--;
        }

        return Vector2.zero; 
    } 
}

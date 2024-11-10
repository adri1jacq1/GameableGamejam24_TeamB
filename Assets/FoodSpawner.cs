using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject foodPrefab;
    public GameObject foodSpawnPosition;
    public GameObject spawnedFood;
    void Start()
    {
        
    }

     
    public void SpawnFood()
    {  
       if(spawnedFood != null)
        {
            Debug.Log("Food already exists");

        }
        else
        {

           spawnedFood = Instantiate(foodPrefab, foodSpawnPosition.transform.position, Quaternion.identity);
        }

    }
}

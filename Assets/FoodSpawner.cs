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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnFood()
    {  
       if(spawnedFood != null)
        {
            spawnedFood = Instantiate(foodPrefab, foodSpawnPosition.transform.position, Quaternion.identity); 
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }
    
    void StartSpawning()
    {
        StartCoroutine(SpawnFood());
    }
    public List<GameObject> restaurantList = new List<GameObject>();
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            int randomIndex = Random.Range(0, restaurantList.Count);
            GameObject randomRestaurant = restaurantList[randomIndex];
            randomRestaurant.GetComponent<FoodSpawner>().SpawnFood();
        }
    }
}

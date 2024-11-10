using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    //public List<GameObject> characterPrefabsList = new List<GameObject>();
     
    public List<GameObject> characterPlacesList  ; 
    void Start()
    {
         
        StartSpawning();
    }

    public void StartSpawning()
    {

       StartCoroutine(SpawnCharacter());
    }

    IEnumerator SpawnCharacter()
    {
           
        while (true)
        {
            yield return new WaitForSeconds(2);

            int randomIndex2 = Random.Range(0, characterPlacesList.Count);
            GameObject randomPlace = characterPlacesList[randomIndex2];
            randomPlace.GetComponent<CharacterPlaceHandler>().SpawnCharacter();
             
            //Instantiate(randomCharacter, randomPlace.transform.position, Quaternion.identity);
            //random
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    //public List<GameObject> characterPrefabsList = new List<GameObject>();
    public GameObject characterPrefab;
    public List<GameObject> characterPlacesList = new List<GameObject>();
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
            GameObject character = Instantiate(characterPrefab, randomPlace.transform.position, Quaternion.identity);
            character.GetComponent<CharacterSetter>().SetCharacter();
            //Instantiate(randomCharacter, randomPlace.transform.position, Quaternion.identity);
            //random
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

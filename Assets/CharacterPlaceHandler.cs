using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlaceHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject characterPrefab;
    public GameObject spawnedCharacter;

    public void SpawnCharacter()
    {
        if (spawnedCharacter == null)
        {
           
            GameObject character = Instantiate(characterPrefab, transform.position, Quaternion.identity);
            character.GetComponent<CharacterSetter>().SetCharacter();
            spawnedCharacter = character;
        }
    }
}

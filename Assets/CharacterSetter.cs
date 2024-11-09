using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetter : MonoBehaviour
{
    public List<GameObject> characterList = new List<GameObject>();
    // Start is called before the first frame update
    void OnEnable()
    {
        //for (int i = 0; i < characterList.Count; i++)
        //{
        //    characterList[i].SetActive(false);
        //}
         
    }

    // Update is called once per frame
    public void SetCharacter()
    {
        int randomIndex = Random.Range(0, characterList.Count);
        GameObject randomCharacter = characterList[randomIndex];
        randomCharacter.SetActive(true);
    }
}

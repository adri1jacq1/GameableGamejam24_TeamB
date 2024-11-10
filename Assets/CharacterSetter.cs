using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetter : MonoBehaviour
{
    public List<GameObject> characterList = new List<GameObject>();
    public float characterHealth = 100f;
    // Start is called before the first frame update
    void OnEnable()
    {
        //for (int i = 0; i < characterList.Count; i++)
        //{
        //    characterList[i].SetActive(false);
        //}
         
    }
    private void Update()
    {
         characterHealth -= Time.deltaTime;
        if (characterHealth <= 0)
        {
            characterHealth = 0;
           Destroy(gameObject);
            Debug.Log("  Character is dead.");
            // Additional game-over actions
        }
    }

    private void OnTriggerEnter (Collider collision)
    {
        CharacterSetter characterSetter = collision.gameObject.GetComponent<CharacterSetter>();
        if (characterSetter != null)
        {
            Destroy(collision.gameObject);
            Debug.Log("Character health: " + characterHealth);
        }
     
    }
    // Update is called once per frame
    public void SetCharacter()
    {
        int randomIndex = Random.Range(0, characterList.Count);
        GameObject randomCharacter = characterList[randomIndex];
        randomCharacter.SetActive(true);
    }
     
}

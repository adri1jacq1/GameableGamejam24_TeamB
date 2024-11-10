using System;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float freshnessDuration = 10f;
    private bool isRotten = false;
    //public List<GameObject> foodSprites;
    public GameObject currentSpriteGobj;
    public SO_Ingredient ingredient;

    [SerializeField]
    private SpriteRenderer sprite;

    private void Start()
    {
        // TODO restore random selection
        //int randomIndex = UnityEngine.Random.Range(0, foodSprites.Count);
        //currentSpriteGobj = foodSprites[randomIndex];

        sprite.sprite = ingredient.uiVisual;
    }

    private void Update()
    { 
        if (!isRotten)
        {
            freshnessDuration -= Time.deltaTime;

            if (freshnessDuration <= 0)
            {
                freshnessDuration = 0;
                BecomeRotten();
            }
        }
        if (isRotten)
        {
            freshnessDuration -= Time.deltaTime;
            if (freshnessDuration <= -1)
            { 
                Destroy(gameObject);
            }
        }
    }

    private void BecomeRotten()
    {
        isRotten = true;
        Debug.Log("Food has become rotten!"); 
        GameManager.Instance.HandleFoodRotten();
        sprite.material.color = Color.gray;

    }

    public void EatFood()
    {
        if (!isRotten)
        {
            Debug.Log("Food eaten!");
              GameManager.Instance.HandleFoodEaten();
             
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Cannot eat rotten food!");
        }
    }
}

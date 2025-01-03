using System;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float freshnessDuration = 10f;
    private bool isRotten = false;
    public List<SO_Dish> allDishes;
    public GameObject currentSpriteGobj;
    public SO_Dish dish;

    [SerializeField]
    private SpriteRenderer sprite;

    private void Start()
    {
        int randomIndex = UnityEngine.Random.Range(0, allDishes.Count);
        dish = allDishes[randomIndex];
        sprite.sprite = dish.uiVisual;
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
        
        GameManager.Instance.HandleFoodRotten();
        sprite.material.color = Color.gray;

    }

    public void EatFood()
    {
        if (!isRotten)
        {
             
              GameManager.Instance.HandleFoodEaten();
             
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Cannot eat rotten food!");

        }
    }
}

using System;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float freshnessDuration = 10f;
    private bool isRotten = false;
      
    public static event Action OnFoodRotten;

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
    }

    private void BecomeRotten()
    {
        isRotten = true;
        Debug.Log("Food has become rotten!"); 
        GameManager.Instance.HandleFoodRotten();
        GetComponent<Renderer>().material.color = Color.gray;
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

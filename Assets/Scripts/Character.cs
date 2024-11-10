using System;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public static event Action OnFoodEaten;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        { 
                EatFood();
            
        }
    }

    public void EatFood()
    { 
             GameManager
            .Instance
            .HandleFoodEaten();
        
    }

}

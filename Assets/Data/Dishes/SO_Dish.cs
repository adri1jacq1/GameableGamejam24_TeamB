using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dish", menuName = "Data/Dish", order = 2)]
public class SO_Dish : ScriptableObject
{
    public Sprite uiVisual;
    public List<SO_Ingredient> recipe;
    public float deliveryBonusTime = 5.0f;
}

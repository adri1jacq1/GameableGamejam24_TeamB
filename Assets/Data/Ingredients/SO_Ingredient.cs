using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Data/Ingredient", order = 1)]
public class SO_Ingredient : ScriptableObject
{
    public enum IngredientType
    {
        Fruit,
        Vegetable,
        Meat,
        Cereal
    }

    public IngredientType type;
    public Sprite uiVisual;
    public float lifeTime = 10.0f;
}

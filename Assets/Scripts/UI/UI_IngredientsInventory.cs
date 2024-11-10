using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_IngredientsInventory : MonoBehaviour
{
    [SerializeField]
    public List<UI_Ingredient> uI_IngredientSpacesList;
    private List<SO_Ingredient> ingredientsDataList = new();

    public void TryAddIngredient(SO_Ingredient addedDish)
    {
        if (ingredientsDataList.Count < uI_IngredientSpacesList.Count)
        {
            ingredientsDataList.Add(addedDish);

            for (int index = 0; index < uI_IngredientSpacesList.Count; index++)
            {
                if (index < ingredientsDataList.Count)
                {
                    uI_IngredientSpacesList[index].FielSpace(ingredientsDataList[index]);
                }
                else
                {
                    uI_IngredientSpacesList[index].EmptySpace();
                }
            }
        }
    }

    public SO_Dish RemoveDish()
    {
        SO_Dish removedeDish = null;

        
        return removedeDish;
    }



}

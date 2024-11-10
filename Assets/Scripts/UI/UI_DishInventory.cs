using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_DishInventory : MonoBehaviour
{
    [SerializeField]
    private List<UI_Dish> uI_DishesSpacesList;
    private List<SO_Dish> dishesDataList = new();

    public bool HasFood()
    {
        return dishesDataList.Count > 0;
    }

    public bool IsFull()
    {
        return dishesDataList.Count == uI_DishesSpacesList.Count;
    }

    public void AddDish(SO_Dish addedDish)
    {
        if(dishesDataList.Count < uI_DishesSpacesList.Count)
        {
            dishesDataList.Add(addedDish);

            for (int index = 0; index < uI_DishesSpacesList.Count; index++)
            {
                if (index < dishesDataList.Count)
                {
                    uI_DishesSpacesList[index].FielSpace(dishesDataList[index]);
                }
                else
                {
                    uI_DishesSpacesList[index].EmptySpace();
                }
            }
        }

    }

    public SO_Dish RemoveDish()
    {
        SO_Dish removedeDish = null;

        if (dishesDataList.Count > 0)
        {
            removedeDish = dishesDataList[0];
            dishesDataList.RemoveAt(0);

            for (int index = 0; index < uI_DishesSpacesList.Count; index++)
            {
                if (index < dishesDataList.Count)
                {
                    uI_DishesSpacesList[index].FielSpace(dishesDataList[index]);
                }
                else
                {
                    uI_DishesSpacesList[index].EmptySpace();
                }
            }
        }

        return removedeDish;
    }



}

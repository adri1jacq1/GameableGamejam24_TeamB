using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Dish : MonoBehaviour
{
    private SO_Dish dishData;

    [SerializeField]
    private Image portrait;


    public void FielSpace(SO_Dish insertedDishData)
    {
        dishData = insertedDishData;
        portrait.sprite = dishData.uiVisual;
        portrait.gameObject.SetActive(true);
    }

    public void EmptySpace()
    {
        portrait.sprite = null;
        portrait.gameObject.SetActive(false);
    }
}

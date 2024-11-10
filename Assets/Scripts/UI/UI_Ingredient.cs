using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ingredient : MonoBehaviour
{
    private bool bIsInitialized = false;
    private SO_Ingredient ingredientData;

    [SerializeField]
    private Image portrait;

    [SerializeField]
    private Image timer;
    private float remainingTime = 0.0f;
    [SerializeField]
    private List<Sprite> timerStatesList;

    public void Initialize(SO_Ingredient _ingredientData)
    {
        ingredientData = _ingredientData;

        portrait.sprite = ingredientData.uiVisual;
        remainingTime = ingredientData.lifeTime;

        bIsInitialized = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(bIsInitialized)
        {
            remainingTime -= Time.deltaTime;
            timer.sprite = GetTimerSprite(remainingTime);
        }
    }

    private Sprite GetTimerSprite(float time)
    {
        float percentRemainingTime = remainingTime / ingredientData.lifeTime;

        if (percentRemainingTime <= 0.0f)
        {
            return timerStatesList[0];
        }
        else if (0.000f <= percentRemainingTime && percentRemainingTime <= 0.125f)
        {
            return timerStatesList[1];
        }
        else if (0.125f <= percentRemainingTime && percentRemainingTime <= 0.250f)
        {
            return timerStatesList[2];
        }
        else if (0.250f <= percentRemainingTime && percentRemainingTime <= 0.375f)
        {
            return timerStatesList[3];
        }
        else if (0.375f <= percentRemainingTime && percentRemainingTime <= 0.500f)
        {
            return timerStatesList[4];
        }
        else if (0.500f <= percentRemainingTime && percentRemainingTime <= 0.625f)
        {
            return timerStatesList[5];
        }
        else if (0.625f <= percentRemainingTime && percentRemainingTime <= 0.750f)
        {
            return timerStatesList[6];
        }
        else if (0.750f <= percentRemainingTime && percentRemainingTime <= 0.875f)
        {
            return timerStatesList[7];
        }
        else if (0.875f <= percentRemainingTime && percentRemainingTime <= 1.000f)
        {
            return timerStatesList[8];
        }

        return null;
    }
}

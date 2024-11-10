using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        var txt = "Nb Of Dishes Delivered : " + GameManager.Instance.foodEaten;
        text.SetText(txt);
    }
}

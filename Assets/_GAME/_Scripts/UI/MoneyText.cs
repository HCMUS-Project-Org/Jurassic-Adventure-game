using TMPro;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    [SerializeField] private TMP_Text Money;

    void Update()
    {
        Money.SetText("$" + PlayerController.budget);
    }
}
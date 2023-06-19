using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMoneyLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public void UpdateMoneyText(float money)
    {
        moneyText.text = $"{money}";
    }
}

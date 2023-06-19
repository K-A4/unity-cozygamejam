using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICozyLabel : MonoBehaviour
{
    [SerializeField] private Image cozyLevelImage;
    [SerializeField] private TextMeshProUGUI cozyCountText;
    public void UpdateCozyLevel(float cozy)
    {
        cozyLevelImage.fillAmount = cozy / Player.Instance.CozyOfPlayer.MaxCozy;
        cozyCountText.text = $"{Mathf.RoundToInt(cozy)}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICozyLabel : MonoBehaviour
{
    [SerializeField] private Image cozyLevelImage;
    public void UpdateCozyLevel(float cozy)
    {
        cozyLevelImage.fillAmount = cozy / Player.Instance.CozyOfPlayer.MaxCozy;
    }
}

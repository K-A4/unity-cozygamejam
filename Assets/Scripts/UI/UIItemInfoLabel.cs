using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIItemInfoLabel : MonoBehaviour
{
    [SerializeField] private GameObject labelGraphics;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemHealthText;
    [SerializeField] private GameObject HealthLabel;

    private RoomItem displayedItem = null;


    private void Start()
    {
        labelGraphics.SetActive(false);
    }

    public void StartDisplayingItemInfo(Transform item)
    {
        if(item.gameObject.TryGetComponent(out displayedItem))
        {
            labelGraphics.SetActive(true);
        }
    }

    public void StopDisplayingItemInfo(Transform item)
    {
        displayedItem = null;
        labelGraphics.SetActive(false);
    }

    private void Update()
    {
        if(displayedItem != null)
        {
            itemNameText.text = displayedItem.Info.Name;
            if (displayedItem.Info.MaxHealth != 0)
            {
                HealthLabel.SetActive(true);
                itemHealthText.text = $"{displayedItem.Health}/{displayedItem.Info.MaxHealth}";
            }
            else
            {
                HealthLabel.SetActive(false);
            }
        }
        else
        {
            labelGraphics.SetActive(false);
        }
    }
}

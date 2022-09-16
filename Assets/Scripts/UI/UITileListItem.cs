using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITileListItem : MonoBehaviour
{
    public string Name 
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
            nameText.text = value;
        } 
    }

    public Sprite Icon
    {
        get
        {
            return iconImage.sprite;
        }
        set
        {
            iconImage.sprite = value;
        }
    }
    public Action<UITileListItem> OnClick { get; set; }
    
    [Header("Links")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image iconImage;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI[] textItems;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color disabledColor;

    protected string name;

    protected virtual void Awake()
    {
        button.onClick.AddListener(() => OnClick.Invoke(this));
    }

    public void SetTextItem(int index, string text)
    {
        textItems[index].text = text;
    }

    public void OnMouseEnter()
    {
        backgroundImage.color = selectedColor;
    }

    public void OnMouseExit()
    {
        backgroundImage.color = disabledColor;
    }

}

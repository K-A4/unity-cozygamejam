using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            TileName.text = value;
        } 
    }

    public Sprite Icon
    {
        get
        {
            return TileIcon.sprite;
        }
        set
        {
            TileIcon.sprite = value;
        }
    }
    public Action<UITileListItem> OnClick { get; set; }

    [SerializeField] private Text TileName;
    [SerializeField] private Image TileIcon;
    [SerializeField] private Button TileButton;
    [SerializeField] private Text[] TileTextItems;

    protected string name;

    protected virtual void Awake()
    {
        TileButton.onClick.AddListener(() => OnClick.Invoke(this));
    }

    public void SetTextItem(int index, string text)
    {
        TileTextItems[index].text = text;
    }

}

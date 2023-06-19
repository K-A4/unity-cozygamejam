using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class UITileList : MonoBehaviour
{
    public Action<UITileListItem> OnItemClick { get; set; }
    private List<UITileListItem> tileListItems = new List<UITileListItem>();
    private GridLayoutGroup gridLayout;

    private void Awake()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
    }

    private void Add(UITileListItem item)
    {
        item.OnClick += (i) => OnItemClick.Invoke(i);
        tileListItems.Add(item);
        RebuildLayout();
    }

    public UITileListItem Add(UITileListItem tilePrefab, string name, string[] textParams)
    {
        UITileListItem tile = Instantiate(tilePrefab, transform);
        tile.Name = name;
        for(int i = 0; i < textParams.Length; i++)
        {
            tile.SetTextItem(i, textParams[i]);
        }
        Add(tile);
        return tile;
    }

    public void Remove(int index)
    {
        Destroy(tileListItems[index].gameObject);
        tileListItems.RemoveAt(index);
        RebuildLayout();
    }

    public void Clear()
    {
        foreach(var item in tileListItems)
        {
            Destroy(item.gameObject);
        }
        tileListItems.Clear();
        RebuildLayout();
    }

    public UITileListItem GetListItem(int index)
    {
        return tileListItems[index];
    }

    private void RebuildLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(gridLayout.GetComponent<RectTransform>());
        //gridLayout.enabled = false;
        //gridLayout.enabled = true;
    }



}

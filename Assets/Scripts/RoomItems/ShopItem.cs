using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : RoomItem
{
    [SerializeField] private GameObject shopPrefab;

    public override int PlacementRules => throw new System.NotImplementedException();

    public override void Use(CozyOfPlayer cozyOfPlayer)
    {
        shopPrefab.gameObject.SetActive(!shopPrefab.gameObject.activeSelf);
        print(shopPrefab.gameObject.activeSelf);
    }
}

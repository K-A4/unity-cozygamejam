using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : UIWindow
{
    [Header("Data")]
    [SerializeField] private RoomItemsData roomItemsData;

    [Space(1)]
    [Header("UI Links")]
    [SerializeField] private UITileListItem shopTilePrefab;
    [SerializeField] private UITileList tileList;

    private Dictionary<UITileListItem, RoomItem> offersList = new Dictionary<UITileListItem, RoomItem>();

    private void Start()
    {
        CreateOffers();
        tileList.OnItemClick += (tile) => BuyItem(offersList[tile]);
    }

    public void CreateOffers()
    {
        tileList.Clear();
        offersList.Clear();
        for (int i = 0; i < 3; i++)
        {
            int smallInd = Random.Range(0, roomItemsData.smallItems.Length);
            CreateItemTile(roomItemsData.smallItems[smallInd]);
        }
        int largeInd = Random.Range(0, roomItemsData.largeItems.Length);
        CreateItemTile(roomItemsData.largeItems[largeInd]);

    }

    public void BuyItem(RoomItem item)
    {
        CreateOffers();
        gameObject.SetActive(false);
        var newItem = Instantiate(item, Vector3.zero * 1, Quaternion.identity);
        //Debug.Log($"Bought {item.Info.Name}");
    }

    private void CreateItemTile(RoomItem roomItem)
    {
        var itemInfo = roomItem.Info;
        var tile = tileList.Add(
            shopTilePrefab,
            itemInfo.Name,
            new string[] 
            { 
                $"-{itemInfo.Cost}",
                $"{itemInfo.MaxHealth}",
                $"+{itemInfo.CozyPerBuy}/{itemInfo.CozyPerUse}"
            }
        );
        offersList.Add(tile, roomItem);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Shop items")]
    [SerializeField] private RoomItemsData roomItemsData;

    [Space(1)]
    [Header("Prefabs")]
    [SerializeField] private UITileListItem tileListShopItem;

    [Space(1)]
    [Header("Links")]
    [SerializeField] private UITileList tileList;

    private Dictionary<UITileListItem, RoomItem> offersList = new Dictionary<UITileListItem, RoomItem>();

    private void Start()
    {
        CreateOffers();
        tileList.OnItemClick += (i) => BuyItem(offersList[i]);
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
        var newItem = Instantiate(item);
        Player.Instance.Grabber.SetGrabItem(newItem.GetComponent<Rigidbody>(), item.Info.IsLarge);
        //Debug.Log($"Bought {item.Info.Name}");
    }

    private void CreateItemTile(RoomItem roomItem)
    {
        UITileListItem tile = Instantiate(tileListShopItem);//.GetComponent<UITileListItem>();
        var itemInfo = roomItem.Info;
        tile.Name = itemInfo.Name;
        tile.SetTextItem(0, itemInfo.Cost.ToString());
        tile.SetTextItem(1, itemInfo.MaxHealth.ToString());
        tile.SetTextItem(2, $"{itemInfo.CozyPerBuy}/{itemInfo.CozyPerUse}");
        tileList.Add(tile);
        offersList.Add(tile, roomItem);
    } 
}

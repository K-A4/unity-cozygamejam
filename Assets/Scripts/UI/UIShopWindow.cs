using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopWindow : UIWindow
{
    [Header("Data")]
    [SerializeField] private RoomItemsData roomItemsData;

    [Space(1)]
    [Header("UI Links")]
    [SerializeField] private UITileListItem shopTilePrefab;
    [SerializeField] private UITileList tileList;
    [SerializeField] private Button exitButton;
    [SerializeField] private Transform spawnTransform;

    private Dictionary<UITileListItem, RoomItem> offersList = new Dictionary<UITileListItem, RoomItem>();

    protected override void Start()
    {
        base.Start();
        CreateOffers();
        tileList.OnItemClick += (tile) => BuyItem(offersList[tile]);
        exitButton.onClick.AddListener(Hide);
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
        if (Player.Instance.CozyOfPlayer.ChangeMoney(-item.Info.Cost))
        {
            CreateOffers();

            UIGame.HideWindows();
            if (item.Info.IsLarge)
            {
                var newItem = Instantiate(item, spawnTransform.position, Quaternion.identity);
            }
            else
            {
                var newItem = Instantiate(roomItemsData.Box, spawnTransform.position, Quaternion.identity);
                newItem.SetItemPrefab(item);
            }
            Player.Instance.CozyOfPlayer.ChangeCozy(item.Info.CozyPerBuy);
        }

        
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

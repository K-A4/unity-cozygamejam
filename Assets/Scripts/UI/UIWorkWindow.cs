using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WorkOfferInfo
{
    public string Name;
    public float Proffit;
    public float CozyDamage;
}

public class UIWorkWindow : UIWindow
{
    [Header("Data")]
    [SerializeField] private WorkOffersData workOffersData;

    [Space(1)]
    [Header("UI Links")]
    [SerializeField] private UITileList tileList;
    [SerializeField] private UITileListItem workTilePrefab;
    [SerializeField] private Button exitButton;


    private Dictionary<UITileListItem, WorkOfferInfo> offersList = new Dictionary<UITileListItem, WorkOfferInfo>();

    protected override void Start()
    {
        base.Start();
        CreateOffers();
        tileList.OnItemClick += (tile) => CompleteOffer(offersList[tile]);
        exitButton.onClick.AddListener(Hide);
    }

    public void CreateOffers()
    {
        offersList.Clear();
        tileList.Clear();
        for (int i = 0; i < 4; i++)
        {
            int ind = Random.Range(0, workOffersData.OffersList.Length);
            CreateOfferTile(workOffersData.OffersList[ind]);
        }
    }

    public void CreateOfferTile(WorkOfferInfo offerInfo)
    {
        var tile = tileList.Add(
            workTilePrefab,
            offerInfo.Name,
            new string[]
            {
                $"+{offerInfo.Proffit}",
                $"-{offerInfo.CozyDamage}"
            }
        );
        offersList.Add(tile, offerInfo);
    }

    public void CompleteOffer(WorkOfferInfo offerInfo)
    {
        UIGame.HideWindows();
        Player.Instance.CozyOfPlayer.ChangeMoney(offerInfo.Proffit);
        Player.Instance.CozyOfPlayer.ChangeCozy(-offerInfo.CozyDamage);
        CreateOffers();
    }
}

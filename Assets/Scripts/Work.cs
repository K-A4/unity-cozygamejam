using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorkOfferInfo
{
    public string Name;
    public float Proffit;
    public float CozyDamage;
}

public class Work : UIWindow
{
    [Header("Data")]
    [SerializeField] private WorkOffersData workOffersData;

    [Space(1)]
    [Header("UI Links")]
    [SerializeField] private UITileList tileList;
    [SerializeField] private UITileListItem workTilePrefab;

    private Dictionary<UITileListItem, WorkOfferInfo> offersList = new Dictionary<UITileListItem, WorkOfferInfo>();

    private void Start()
    {
        CreateOffers();
        tileList.OnItemClick += (tile) => CompleteOffer(offersList[tile]);
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
        Player.Instance.CozyOfPlayer.ChangeMoney(offerInfo.Proffit);
        Player.Instance.CozyOfPlayer.ChangeCozy(-offerInfo.CozyDamage);
        CreateOffers();
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WorkOffersData", fileName = "Work Offers")]

public class WorkOffersData : ScriptableObject
{
    public WorkOfferInfo[] OffersList;
}

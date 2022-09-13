using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlacementRules : int
{
    Floor   = 0,
    Surface = 1,
    Wall    = 2,
    Ceil    = 4
}

[System.Serializable]
public class RoomItemInfo
{
    public float MaxHealth = 0;
    public float CozyPerBuy = 0;
    public float CozyPerUse = 0;
}

public abstract class RoomItem : MonoBehaviour
{
    public abstract int PlacementRules { get; }
    public float Health { get; protected set; } = 0;
    public RoomItemInfo Info { get; protected set; }

    public void SetParams(RoomItemInfo info)
    {
        this.Info = info;
        Health = info.MaxHealth;
    }

    public abstract void Use(CozyOfPlayer cozyOfPlayer);
}

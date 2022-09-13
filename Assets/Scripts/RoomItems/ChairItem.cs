using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairItem : RoomItem
{
    [SerializeField] private Transform sitPos;
    public override int PlacementRules => throw new System.NotImplementedException();

    public override void Use(CozyOfPlayer cozyOfPlayer)
    {
        //cozyOfPlayer.transform .position Vectoc2.lerp
    }
}

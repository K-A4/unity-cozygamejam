using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableItem : RoomItem
{
    public override int PlacementRules => (int)EPlacementRules.Floor;
    public override void Use(CozyOfPlayer cozyOfPlayer)
    {
        cozyOfPlayer.ChangeCozy(Info.CozyPerUse);
    }
}

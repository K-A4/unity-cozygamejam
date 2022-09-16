using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupItem : RoomItem
{
    public override int PlacementRules => throw new System.NotImplementedException();

    public override void Use(CozyOfPlayer cozyOfPlayer)
    {
        cozyOfPlayer.ChangeCozy(Info.CozyPerUse);
        StartCoroutine(ParticleData.PlayParticle(transform));
        Health--;
    }
}

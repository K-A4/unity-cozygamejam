using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupItem : RoomItem
{
    public override int PlacementRules => throw new System.NotImplementedException();

    public override void Use(CozyOfPlayer cozyOfPlayer)
    {
        //cozyOfPlayer.ChangeCozy(Info.CozyPerUse);
        ParticleManager.CreateItemEffect(
            transform, 
            ParticleManager.Particles.PsWaterDrink, 
            () => {
                cozyOfPlayer.ChangeCozy(Info.CozyPerUse);
                Health--; 
            }
        );
        //StartCoroutine(ParticleManager.PlayParticle(transform));
        //Health--;
    }
}

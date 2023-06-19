using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupItem : RoomItem
{
    public override int PlacementRules => throw new System.NotImplementedException();

    public override void Use(Vector3 UsePos)
    {
        //cozyOfPlayer.ChangeCozy(Info.CozyPerUse);
        ParticleManager.CreateItemEffect(
            transform, 
            ParticleManager.Particles.PsWaterDrink, 
            () => {
                Player.Instance.CozyOfPlayer.ChangeCozy(Info.CozyPerUse);
                Health--; 
            },
            GetComponent<Renderer>().material
        );
        //StartCoroutine(ParticleManager.PlayParticle(transform));
        //Health--;
    }
}

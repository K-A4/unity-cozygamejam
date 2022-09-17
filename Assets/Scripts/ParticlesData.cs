using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ParticlesData", fileName = "Particle prefabs")]
public class ParticlesData : ScriptableObject
{
    public ParticleSystem PsDestroyItem;
    public ParticleSystem PsWaterDrink;
    public ParticleSystem PsItemUseDefault;
}

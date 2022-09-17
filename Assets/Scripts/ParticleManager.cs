using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance { get; private set; }
    public static ParticlesData Particles => Instance.particles;
    [SerializeField] private ParticlesData particles;


    private void Awake()
    {
        Instance = this;
    }

    public static void CreateDestroyItemEffect(Vector3 position, Material parentMaterial)
    {
        var ps = Instantiate(Instance.particles.PsDestroyItem, position, Quaternion.identity);
        ps.gameObject.GetComponent<Renderer>().material = parentMaterial;
        Instance.StartCoroutine(Instance.PlayingParticleCorutine(ps));
    }

    public static void CreateItemEffect(Transform itemTransform, ParticleSystem particleSystemPrefab, Action onSimulationEnd = null)
    {
        var ps = Instantiate(particleSystemPrefab, itemTransform);
        Instance.StartCoroutine(Instance.PlayingParticleCorutine(ps, onSimulationEnd));
    }

    //public static IEnumerator PlayParticle(Transform transform)
    //{
    //    var particle = Instantiate(Instance.particles.PsWaterDrink, transform);
    //    particle.Play();

    //    while (true)
    //    {
    //        if (particle.isPlaying)
    //        {
    //            yield return null;
    //        }
    //        else
    //        {
    //            Destroy(particle.gameObject);
    //            yield break;
    //        }
    //    }
    //}

    private IEnumerator PlayingParticleCorutine(ParticleSystem ps, Action onSimulationEnd = null)
    {
        ps.Play();
        while (ps.isPlaying)
        {
            yield return null;
        }
        Destroy(ps.gameObject);
        onSimulationEnd?.Invoke();
    }
}

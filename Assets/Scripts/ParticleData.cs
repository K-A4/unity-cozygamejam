using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleData : MonoBehaviour
{
    public static ParticleSystem Particle;
    [SerializeField] private ParticleSystem ParticleSystem;

    private void Start()
    {
        Particle = ParticleSystem;
    }

    public static IEnumerator PlayParticle(Transform transform)
    {
        var particle = Instantiate(Particle, transform);
        particle.Play();

        while (true)
        {
            if (particle.isPlaying)
            {
                yield return null;
            }
            else
            {
                Destroy(particle.gameObject);
                yield break;
            }
        }
    }
}

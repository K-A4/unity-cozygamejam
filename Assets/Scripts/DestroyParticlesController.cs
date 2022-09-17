using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticlesController : MonoBehaviour
{
    private ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void SetParticlesMaterial(Material mat)
    {
        GetComponent<Renderer>().material = mat;
    }
}

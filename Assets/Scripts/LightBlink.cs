using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
    private Light light;
    private float intensity;
    [SerializeField] private float intensityRange = 0.5f;

    private void Start()
    {
        light = GetComponent<Light>();
        intensity = light.intensity;
    }

    private void Update()
    {
        light.intensity = intensity - (Random.value + Mathf.Sin(Time.time * 2)) * intensityRange;
    }
}

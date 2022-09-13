using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CozyOfPlayer : MonoBehaviour
{
    public float Cozy { get; }

    public UnityEvent<float> CozyChanged;

    public UnityEvent EndCozyEvent;

    private float cozy;

    public void ChangeCozy(float value)
    {
        cozy += value;

        if (cozy < 0)
        {
            cozy = 0;
            EndCozyEvent.Invoke();
        }

        CozyChanged.Invoke(cozy);
    }
}

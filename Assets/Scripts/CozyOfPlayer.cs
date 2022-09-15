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
    [SerializeField] private float defaultCozy;

    private void Start()
    {
        cozy = defaultCozy;
    }

    private void Update()
    {
        ChangeCozy(-Time.deltaTime * Time.deltaTime);
    }

    public void ChangeCozy(float value)
    {
        cozy += value;

        if (cozy < 0)
        {
            cozy = 0;
            EndCozyEvent.Invoke();
        }

        CozyChanged.Invoke(cozy/defaultCozy);
    }
}

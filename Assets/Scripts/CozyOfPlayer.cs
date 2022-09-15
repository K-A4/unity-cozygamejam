using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CozyOfPlayer : MonoBehaviour
{
    public float Cozy { get; }

    public UnityEvent<float> OnCozyChanged;

    public UnityEvent OnEndCozyEvent;

    private float cozy;
    [SerializeField] private float defaultCozy;

    private void Start()
    {
        cozy = defaultCozy;
    }

    private void Update()
    {
        ChangeCozy(- Time.time * Time.time);
    }

    public void ChangeCozy(float value)
    {
        cozy += value;

        if (cozy < 0)
        {
            cozy = 0;
            OnEndCozyEvent.Invoke();
        }

        OnCozyChanged.Invoke(cozy / defaultCozy);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CozyOfPlayer : MonoBehaviour
{
    public float Cozy { get; private set; } = 0;
    public float MaxCozy => maxCozyCount;
    public float Money { get; private set; } = 0;
    public float Skills { get; private set; } = 0;



    public UnityEvent<float> OnCozyChanged;
    public UnityEvent<float> OnMoneyChanged;
    public UnityEvent OnEndCozyEvent;

    [SerializeField] private float startCozyCount = 100;
    [SerializeField] private float maxCozyCount = 100;
    [SerializeField] private float startMoneyCount;

    private void Start()
    {
        SetCozy(startCozyCount);
        SetMoney(startMoneyCount);
    }

    public void ChangeCozy(float value)
    {
        if (!LevelManager.IsGameEnded)
        {
            SetCozy(Cozy + value);
        }
    }

    public bool ChangeMoney(float value)
    {
        return SetMoney(Money + value);
    }

    public bool SetMoney(float value)
    {
        if (value < 0)
            return false;

        Money = value;
        OnMoneyChanged.Invoke(Money);
        return true;
    }

    public void SetCozy(float value)
    {
        Cozy = value;
        if (Cozy <= 0)
        {
            Cozy = 0;
            OnEndCozyEvent.Invoke();
        }

        OnCozyChanged.Invoke(Cozy);
    }
}

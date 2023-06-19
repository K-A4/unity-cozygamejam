using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlacementRules : int
{
    Floor   = 0,
    Surface = 1,
    Wall    = 2,
    Ceil    = 4
}

[System.Serializable]
public class RoomItemInfo
{
    public string Name = "";
    public float Cost = 0;
    public float MaxHealth = 0;
    public float CozyPerBuy = 0;
    public float CozyPerUse = 0;
    public bool IsLarge = false;
}

public abstract class RoomItem : MonoBehaviour
{
    public abstract int PlacementRules { get; }
    public float Health 
    {
        get
        {
            return health;
        }
        protected set
        {
            health = value;
            if(health <= 0)
            {
                OnEndHealth();
            }
        } 
    }

    private float health;
    public RoomItemInfo Info => info;
    [SerializeField] private RoomItemInfo info;
    [SerializeField] private float itemMaxCD = 1.0f;
    private float timeCD;

    private void Update()
    {
        timeCD += Time.deltaTime;
    }

    public bool IsReady()
    {
        if (timeCD > itemMaxCD)
        {
            timeCD = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual void Awake()
    {
        health = Info.MaxHealth;
        gameObject.layer = LayerMask.NameToLayer("Interact");
    }

    protected virtual void Start()
    {
        ParticleManager.CreateItemEffect(transform, ParticleManager.Particles.PsCreateItem);
    }

    public virtual void Use(Vector3 UsePos)
    {
        Debug.Log($"Using {Info.Name}...");
        var pos = UsePos;

        if (!Info.IsLarge)
        {
            pos = Vector3.zero;
        }

        ParticleManager.CreateItemEffect(
                transform,
                ParticleManager.Particles.PsItemUseDefault, pos,
                () =>
                {
                    Player.Instance.CozyOfPlayer.ChangeCozy(Info.CozyPerUse);
                    Health--;
                }
            );
    }

    public virtual void OnEndHealth()
    {
        ParticleManager.CreateDestroyItemEffect(transform.position, GetComponent<Renderer>().material);
        Destroy(gameObject);
    }
}

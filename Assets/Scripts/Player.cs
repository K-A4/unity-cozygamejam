using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; protected set; }
    public CozyOfPlayer CozyOfPlayer;
    public Grabber Grabber;

    private void Awake()
    {
        Instance = this;
    }
}

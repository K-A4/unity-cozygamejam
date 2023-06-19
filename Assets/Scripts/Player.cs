using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; protected set; }
    public CozyOfPlayer CozyOfPlayer;
    public Grabber Grabber;
    public CameraLook Cameralook;
    public PlayerMovement PlayerMovement;
    public Interactor Interactor;

    private void Awake()
    {
        Instance = this;
    }

    public void SetLock(bool islock)
    {
        Grabber.enabled = islock;
        Cameralook.enabled = islock;
        PlayerMovement.enabled = islock;
        Interactor.enabled = islock;
    }
}

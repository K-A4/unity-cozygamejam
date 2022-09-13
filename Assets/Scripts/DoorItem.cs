using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorItem : RoomItem
{
    public override int PlacementRules => throw new System.NotImplementedException();

    private bool open;

    private Quaternion openAngle;

    private void Start()
    {
        openAngle = transform.rotation;
    }

    public override void Use(CozyOfPlayer cozyOfPlayer)
    {
        DoorInteract();
    }

    private void DoorInteract()
    {
        open = !open;
    }

    private void OpenDoor()
    {

    }
}

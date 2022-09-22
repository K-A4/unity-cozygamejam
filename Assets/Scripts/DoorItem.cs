using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorItem : RoomItem
{
    public override int PlacementRules => throw new System.NotImplementedException();
    private bool open;
    private Quaternion closeAngle;
    [SerializeField] private float openAngle;

    private void Start()
    {
        closeAngle = transform.rotation;
    }

    public override void Use()
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

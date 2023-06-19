using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowOpenerItem : RoomItem
{
    [SerializeField] private EWindow windowType;
    public override int PlacementRules => throw new System.NotImplementedException();

    public override void Use(Vector3 UsePos)
    {
        UIGame.ShowWindow(windowType);
    }
}

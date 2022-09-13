using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="RoomItemsData", fileName = "Room Items")]
public class RoomItemsData : ScriptableObject
{
    public RoomItem[] largeItems;
    public RoomItem[] smallItems;
}

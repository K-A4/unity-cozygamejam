using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxItem : RoomItem
{
    public override int PlacementRules => throw new System.NotImplementedException();

    private RoomItem ItemPrefab;
    private UnityEvent OnUnbox;

    public void SetItemPrefab(RoomItem item)
    {
        ItemPrefab = item;
    }

    public override void Use(Vector3 UsePos)
    {
        if (ItemPrefab)
        {
            Instantiate(ItemPrefab, transform.position, transform.rotation);
            OnUnbox?.Invoke();
            Destroy(gameObject);
        }
    }
}

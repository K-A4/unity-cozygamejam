using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> onHover;

    private void Update()
    {
        RaycastHit hit;
        bool hover = false;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Interact"))
            {
                hover = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.transform.TryGetComponent(out RoomItem interactItem))
                    {
                        InteractWith(interactItem);
                    }
                }
            }
        }

        onHover?.Invoke(hover);
    }

    private void InteractWith(RoomItem interactItem)
    {
        interactItem.Use(Player.Instance.CozyOfPlayer);
    }
}

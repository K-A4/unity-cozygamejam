using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> onHover;
    [SerializeField] private UnityEvent<Transform> onHoverBegin;
    [SerializeField] private UnityEvent<Transform> onHoverEnd;

    private Transform hoverObject = null;

    private void Update()
    {
        RaycastHit hit;
        //bool hover = false;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2)
            && hit.transform.gameObject.layer == LayerMask.NameToLayer("Interact"))
        {
            if(hoverObject == null || hoverObject != hit.transform)
            {
                if (hoverObject != null)
                    onHoverEnd.Invoke(hoverObject);

                hoverObject = hit.transform;
                onHoverBegin.Invoke(hoverObject);
            }
            //hover = true;
                
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.TryGetComponent(out RoomItem interactItem))
                {
                    InteractWith(interactItem);
                }
            }
        }
        else
        {
            if (hoverObject != null)
                onHoverEnd.Invoke(hoverObject);

            hoverObject = null;
        }

        onHover?.Invoke(hoverObject != null);
    }

    private void InteractWith(RoomItem interactItem)
    {
        interactItem.Use();
    }
}

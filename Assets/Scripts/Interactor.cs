using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private CozyOfPlayer cozyPlayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
            {
                RoomItem interactItem= hit.transform.GetComponent<RoomItem>();
                InteractWith(interactItem);
            }
        }
    }
    private void InteractWith(RoomItem interactItem)
    {
        interactItem.Use(cozyPlayer);
    }
}

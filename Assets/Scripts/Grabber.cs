using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    [SerializeField] private float grabDistance;
    private Rigidbody grabbedRb;
    private bool isGrabbing;
    private float distance;
    private Quaternion prevRotation;
    private Vector3 grabOffset;
    private bool isLarge = false;

    public void SetGrabItem(Rigidbody grabItem, bool isLarge)
    {
        grabbedRb = grabItem;
        isGrabbing = true;
        grabbedRb.isKinematic = true;

        distance = 2;
        this.isLarge = isLarge;
        prevRotation = transform.rotation;
    }

    private void Update()
    {
        GrabInput();

        Grabbing();
    }

    private void Grabbing()
    {
        if (isGrabbing)
        {
            if (grabbedRb)
            {
                if (isLarge)
                {
                    var ray = new Ray(transform.position, transform.forward);
                    //out RaycastHit hitInfo, 
                    var hitInfo = Physics.RaycastAll(ray, float.MaxValue, LayerMask.NameToLayer("Player"));
                    //var deltaRot = transform.rotation * Quaternion.Inverse(prevRotation);
                    var eA = transform.rotation.eulerAngles;
                    grabbedRb.transform.rotation = Quaternion.Euler(0, eA.y, 0);

                    //grabbedRb.transform.up = Vector3.up;

                    grabbedRb.transform.position = hitInfo[0].point + hitInfo[0].normal*0.1f;
                    //prevRotation = transform.rotation;
                }
                else
                {
                    var deltaRot = transform.rotation * Quaternion.Inverse(prevRotation);
                    grabbedRb.position = transform.position + (transform.forward * distance);
                    grabbedRb.rotation = deltaRot * grabbedRb.rotation;
                    prevRotation = transform.rotation;
                }
            }
        }
    }

    private void GrabInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, grabDistance, LayerMask.NameToLayer("Player")))
            {
                isGrabbing = true;
                grabbedRb = hitInfo.rigidbody;
                grabbedRb.isKinematic = true;
                distance = hitInfo.distance;
                grabOffset = grabbedRb.position - transform.position;
                prevRotation = transform.rotation;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (grabbedRb)
            {
                grabbedRb.isKinematic = false;
            }
            isGrabbing = false;
        }
    }
}

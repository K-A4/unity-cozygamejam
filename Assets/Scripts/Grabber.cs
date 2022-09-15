using System;
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
    private int layer;

    private void Update()
    {
        GrabInput();

        Grabbing();
        Debug.DrawRay(transform.position, transform.forward*10);
    }

    private void Grabbing()
    {
        if (isGrabbing)
        {
            if (grabbedRb)
            {
                if (isLarge)
                {
                    PlaceOnSurface();
                }
                else
                {
                    GrabInHand();
                }
                prevRotation = transform.rotation;
            }
        }
    }

    private void GrabInHand()
    {
        var deltaRot = transform.rotation * Quaternion.Inverse(prevRotation);
        grabbedRb.position = transform.position + (transform.forward * distance) + grabbedRb.transform.TransformVector(grabOffset);
        grabbedRb.rotation = deltaRot * grabbedRb.rotation;
    }

    private void PlaceOnSurface()
    {
        var ray = new Ray(transform.position, transform.forward);
        var hitInfo = Physics.RaycastAll(ray, float.MaxValue);
        var deltaRot = transform.rotation * Quaternion.Inverse(prevRotation);

        if (hitInfo.Length > 1)
        {
            var eA = deltaRot.eulerAngles;
            var rot = grabbedRb.transform.rotation.eulerAngles;
            grabbedRb.transform.rotation = Quaternion.Euler(0, rot.y, 0);
            grabbedRb.transform.rotation = Quaternion.Euler(0, eA.y, 0) * grabbedRb.transform.rotation;
            grabbedRb.transform.position = hitInfo[0].point + hitInfo[0].normal * 0.1f;
        }
        else
        {
            GrabInHand();
        }
    }
    private void GrabInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, grabDistance))
            {
                isGrabbing = true;
                grabbedRb = hitInfo.rigidbody;
                if (grabbedRb)
                {
                    isLarge = grabbedRb.tag == "Large";

                    grabbedRb.isKinematic = true;
                    distance = hitInfo.distance;
                    grabOffset = grabbedRb.transform.InverseTransformVector(grabbedRb.position - hitInfo.point);
                    prevRotation = transform.rotation;
                    layer = grabbedRb.gameObject.layer;
                    grabbedRb.gameObject.layer = LayerMask.NameToLayer("Grabbed");
                }
            }
        }

        if (isGrabbing)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (grabbedRb)
                {
                    grabbedRb.isKinematic = false;
                    grabbedRb.gameObject.layer = layer;
                }
                isGrabbing = false;
            }
        }
    }
}

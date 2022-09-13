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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = new Ray(transform.position, transform.forward * grabDistance);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, LayerMask.NameToLayer("Player")))
            {
                isGrabbing = true;
                grabbedRb = hitInfo.rigidbody;
                grabbedRb.isKinematic = true;
                distance = hitInfo.distance;
                grabOffset = grabbedRb.position - transform.position;
                prevRotation = transform.rotation;
            }
        }
        
        if (isGrabbing)
        {
            if (grabbedRb)
            {
                var deltaRot = transform.rotation * Quaternion.Inverse(prevRotation);
                grabbedRb.position = transform.position + transform.TransformVector(grabOffset);
                //Debug.DrawLine();
                Debug.DrawLine(transform.position, transform.position + transform.InverseTransformVector(grabOffset));
                grabbedRb.rotation = deltaRot * grabbedRb.rotation;
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

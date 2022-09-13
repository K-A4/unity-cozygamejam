using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float sensetivity;
    [SerializeField] private Transform playerTransform;
    private Vector3 prevMouse;
    private float angle;
    private Vector3 mousePosition () => new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));

    private void Start()
    {
        prevMouse = mousePosition();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var deltamouse = mousePosition() - prevMouse;
        angle -= deltamouse.y * sensetivity;
        angle = Mathf.Clamp(angle, -90, 90);
        transform.localRotation = Quaternion.Euler(angle, 0,0);
        prevMouse = mousePosition();
        playerTransform.rotation = Quaternion.Euler(0, deltamouse.x * sensetivity, 0) * playerTransform.rotation;
    }
}

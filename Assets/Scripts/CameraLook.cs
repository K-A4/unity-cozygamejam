using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float sensetivity;
    [SerializeField] private Transform playerTransform;
    private float angle;
    private Vector3 mousePosition() => new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var deltamouse = mousePosition();

        angle -= deltamouse.y * sensetivity;
        angle = Mathf.Clamp(angle, -90, 90);
        transform.localRotation = Quaternion.Euler(angle, 0,0);

        playerTransform.rotation = Quaternion.Euler(0, deltamouse.x * sensetivity, 0) * playerTransform.rotation;
    }
}

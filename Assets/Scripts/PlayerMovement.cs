using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));

        if (inputVector != Vector2.zero)
        {
            inputVector.Normalize();
            Vector3 deltaPos = (transform.forward * inputVector.x + transform.right * inputVector.y) * speed * Time.deltaTime;
            transform.position += deltaPos;
        }
    }
}

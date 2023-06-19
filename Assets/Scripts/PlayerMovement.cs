using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 InputVector { get; protected set; }
    [SerializeField] private float speed;

    private void Update()
    {
        InputVector = new Vector3(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"), 0);
        
        if (InputVector != Vector3.zero)
        {
            InputVector.Normalize();
            Vector3 deltaPos = (transform.forward * InputVector.x + transform.right * InputVector.y) * speed * Time.deltaTime;
            transform.position += deltaPos;
        }
    }
}

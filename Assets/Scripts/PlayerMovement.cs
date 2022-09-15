using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isLocked;

    private void Update()
    {
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        
        if (inputVector != Vector2.zero && !isLocked)
        {
            inputVector.Normalize();
            Vector3 deltaPos = (transform.forward * inputVector.x + transform.right * inputVector.y) * speed * Time.deltaTime;
            transform.position += deltaPos;
        }
    }
    public void SetLock(bool locked)
    {
        isLocked = locked;
    }
}

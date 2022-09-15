using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Player.Instance.SetLock(false);
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Player.Instance.SetLock(true);
    }
}

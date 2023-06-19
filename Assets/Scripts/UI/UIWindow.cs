using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    protected GameObject body;

    protected virtual void Start()
    {
        body = transform.GetChild(0).gameObject;
        body.SetActive(false);
    }

    public virtual void Show()
    {
        Cursor.lockState = CursorLockMode.None;
        Player.Instance.SetLock(false);
        body.SetActive(true);
    }

    public virtual void Hide()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Player.Instance.SetLock(true);
        body.SetActive(false);
    }
}

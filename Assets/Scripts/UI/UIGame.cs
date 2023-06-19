using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EWindow
{
    Shop,
    Work,
    GameOver
}

public class UIGame : MonoBehaviour
{

    private static UIGame instance;

    [Header("UI Windows")]
    [SerializeField] private UIWindow[] windows;


    private void Awake()
    {
        instance = this;
    }

    public static void ShowWindow(EWindow windowType)
    {
        UIWindow ow = GetWindow(windowType);
        foreach(var w in instance.windows)
        {
            if(ow != w)
            {
                w.Hide();
            }
        }
        ow.Show();
    }

    public static void HideWindows()
    {
        foreach(var w in instance.windows)
        {
            w.Hide();
        }
    }


    public static UIWindow GetWindow(EWindow type)
    {
        return instance.GetWindowByType(type);
    }

    private UIWindow GetWindowByType(EWindow type)
    {
        foreach(var w in windows)
        {
            if(CheckWindow(type, w))
            {
                return w;
            }
        }

        return null;
    }

    private bool CheckWindow(EWindow type, UIWindow w)
    {
        switch (w)
        {
            case UIShopWindow:
                return type == EWindow.Shop;
            case UIWorkWindow:
                return type == EWindow.Work;
            case UIGameOverWindow:
                return type == EWindow.GameOver;
            default:
                return false;
        }
        
    }

}

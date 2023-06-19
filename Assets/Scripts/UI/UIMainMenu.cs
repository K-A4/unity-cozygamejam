using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("OneRoom");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

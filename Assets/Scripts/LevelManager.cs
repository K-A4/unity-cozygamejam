using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool IsGameEnded { get; private set; }

    [SerializeField] private float cozyDecreaseSpeed = 2;

    private static LevelManager instance;

    private void Start()
    {
        instance = this;
        Player.Instance.CozyOfPlayer.OnEndCozyEvent.AddListener(EndGame);
        ((UIGameOverWindow)UIGame.GetWindow(EWindow.GameOver)).onRestartGame.AddListener(RestartGame);
    }

    private void Update()
    {
        if (!IsGameEnded)
        {
            Player.Instance.CozyOfPlayer.ChangeCozy(-Time.deltaTime * cozyDecreaseSpeed);
        }
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene("OneRoom");
    }

    public void EndGame()
    {
        IsGameEnded = true;
        UIGame.ShowWindow(EWindow.GameOver);
    }
}

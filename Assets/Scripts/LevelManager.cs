using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static bool IsGameEnded { get; private set; }

    [SerializeField] private float maxDecreaseSpeed = 2;
    [SerializeField] private float decreaseAcc = 0.1f;
    private float decreaseSpeed = 2;

    private static LevelManager instance;

    private void Start()
    {
        instance = this;
        Player.Instance.CozyOfPlayer.OnEndCozyEvent.AddListener(EndGame);
        ((UIGameOverWindow)UIGame.GetWindow(EWindow.GameOver)).onRestartGame.AddListener(RestartGame);
    }

    private void Update()
    {
        decreaseSpeed += Time.deltaTime * decreaseAcc;

        if (decreaseSpeed >= maxDecreaseSpeed)
        {
            decreaseSpeed = maxDecreaseSpeed;
        }

        Player.Instance.CozyOfPlayer.ChangeCozy(-Time.deltaTime * decreaseSpeed);
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

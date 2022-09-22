using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class UIGameOverWindow : UIWindow
{
    [Header("UI Links")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    [Space(1)]
    [Header("Events")]
    public UnityEvent onRestartGame;
    public UnityEvent onExitGame;


    protected override void Start()
    {
        base.Start();
        restartButton.onClick.AddListener(() => onRestartGame?.Invoke());
        exitButton.onClick.AddListener(() => onExitGame?.Invoke());
    }

    public override void Show()
    {
        base.Show();
        TimeSpan t = TimeSpan.FromSeconds(Time.time);
        timeText.text = $"Your life was cozy for {t.Minutes} min. {t.Seconds} sec.";
    }
}

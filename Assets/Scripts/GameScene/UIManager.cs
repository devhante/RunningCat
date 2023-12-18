using System;
using System.Collections;
using System.Collections.Generic;
using RunningCat;
using RunningCat.GameScene;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text obstacleText;
    [SerializeField] private TMP_Text churuText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    protected override void Awake()
    {
        base.Awake();
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    private void Update()
    {
        scoreText.text = GameManager.instance.score.ToString();
        obstacleText.text = GameManager.instance.obstacle.ToString();
        churuText.text = GameManager.instance.churu.ToString();
    }

    private void OnClickRestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OnClickExitButton()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}

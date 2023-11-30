using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RunningCat.LobbyScene
{
    public class LobbyButtons : MonoBehaviour
    {
        [SerializeField] private Button gameStartButton;
        [SerializeField] private Button checkScoreButton;
        [SerializeField] private Button gameQuitButton;
        [SerializeField] private GameObject checkScorePanel;

        private void Start()
        {
            gameStartButton.onClick.AddListener(OnClickGameStartButton);
            checkScoreButton.onClick.AddListener(OnClickCheckScoreButton);
            gameQuitButton.onClick.AddListener(OnClickGameQuitButton);
        }

        private void OnClickGameStartButton()
        {
            SceneManager.LoadScene("GameScene");
        }

        private void OnClickCheckScoreButton()
        {
            checkScorePanel.SetActive(true);
        }

        private void OnClickGameQuitButton()
        {
            Application.Quit();
        }
    }
}
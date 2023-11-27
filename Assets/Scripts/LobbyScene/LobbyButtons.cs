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

        private void Start()
        {
            gameStartButton.onClick.AddListener(OnClickGameStartButton);
        }

        private void OnClickGameStartButton()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
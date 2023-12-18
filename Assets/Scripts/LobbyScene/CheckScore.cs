using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RunningCat.LobbyScene
{
    public class CheckScore : MonoBehaviour
    {
        [SerializeField] private Button backgroundButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private TMP_Text[] bestScores;

        private void Start()
        {
            backgroundButton.onClick.AddListener(OnClickBackgroundButton);
            closeButton.onClick.AddListener(OnClickCloseButton);
        }

        private void Update()
        {
            for (int i = 0; i < 3; i++)
            {
                bestScores[i].text = BestScore.instance.bestScores[i].ToString();
            }
        }

        private void OnClickBackgroundButton()
        {
            gameObject.SetActive(false);
        }

        private void OnClickCloseButton()
        {
            gameObject.SetActive(false);
        }
    }
}
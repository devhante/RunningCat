using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RunningCat.LobbyScene
{
    public class CheckScore : MonoBehaviour
    {
        [SerializeField] private Button backgroundButton;
        [SerializeField] private Button closeButton;

        private void Start()
        {
            backgroundButton.onClick.AddListener(OnClickBackgroundButton);
            closeButton.onClick.AddListener(OnClickCloseButton);
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
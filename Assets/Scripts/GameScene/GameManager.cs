using System;
using System.Collections;
using UnityEngine;

namespace RunningCat.GameScene
{
    public class GameManager : Singleton<GameManager>
    {
        public int obstacle;
        public int churu;
        public int score;

        public bool gameOver;

        public float speed;

        [SerializeField] private GameObject gameOverPanel;

        protected override void Awake()
        {
            base.Awake();
            obstacle = 0;
            churu = 0;
            score = 0;
            gameOver = false;
            speed = 0;
        }

        private void Start()
        {
            StartCoroutine(SpeedCoroutine());
        }
        
        IEnumerator SpeedCoroutine()
        {
            while (!gameOver)
            {
                yield return new WaitForSeconds(10);
                speed += 0.2f;
            }
        }

        public void GameOver()
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
            Player.instance.Idle();
            BestScore.instance.SetBestScore(score);
        }
    }
}

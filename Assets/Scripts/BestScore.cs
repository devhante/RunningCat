using System;
using System.Collections;
using System.Collections.Generic;
using RunningCat;
using UnityEngine;

namespace RunningCat
{
    public class BestScore : Singleton<BestScore>
    {
        public int[] bestScores;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            bestScores = new int[3];
            Load();
        }

        public void SetBestScore(int score)
        {
            if (score >= bestScores[0])
            {
                bestScores[2] = bestScores[1];
                bestScores[1] = bestScores[0];
                bestScores[0] = score;
            }
            else if (score >= bestScores[1])
            {
                bestScores[2] = bestScores[1];
                bestScores[1] = score;
            }
            else if (score >= bestScores[2])
            {
                bestScores[2] = score;
            }

            Save();
        }

        private void Save()
        {
            PlayerPrefs.SetInt("Score0", bestScores[0]);
            PlayerPrefs.SetInt("Score1", bestScores[1]);
            PlayerPrefs.SetInt("Score2", bestScores[2]);
        }

        private void Load()
        {
            if (PlayerPrefs.HasKey("Score0"))
            {
                bestScores[0] = PlayerPrefs.GetInt("Score0");
            }

            if (PlayerPrefs.HasKey("Score1"))
            {
                bestScores[1] = PlayerPrefs.GetInt("Score1");
            }

            if (PlayerPrefs.HasKey("Score2"))
            {
                bestScores[2] = PlayerPrefs.GetInt("Score2");
            }
        }
    }
}
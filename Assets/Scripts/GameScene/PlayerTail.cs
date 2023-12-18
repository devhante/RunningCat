using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunningCat.GameScene
{
    public class PlayerTail : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Train"))
            {
                GameManager.instance.GameOver();
            }
        }
    }
}
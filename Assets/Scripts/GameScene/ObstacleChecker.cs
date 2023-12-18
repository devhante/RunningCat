using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunningCat.GameScene
{
    public class ObstacleChecker : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                var om = other.GetComponent<ObstacleMove>();
                if (!om.isScored)
                {
                    om.isScored = true;
                    if (!om.isHit)
                    {
                        GameManager.instance.obstacle++;
                        if (Player.instance.energyTime > 0)
                        {
                            GameManager.instance.score += 20;
                        }
                        else
                        {
                            GameManager.instance.score += 10;
                        }
                    }
                }
            }
        }
    }
}
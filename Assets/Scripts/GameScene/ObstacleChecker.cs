using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            var om = other.GetComponent<ObstacleMove>();
            if (!om.isScored)
            {
                om.isScored = true;
                if (om.isHit)
                {
                    // Score 상승
                }
            }
        }
    }
}

using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [HideInInspector] public bool isHit = false;
    [HideInInspector] public bool isScored = false;

    [Tooltip("장애물의 스피드")]
    [SerializeField] float obstacleSpeed = 1f;
    [Tooltip("장애물이 파괴되는 시간 간격")]
    [SerializeField] float destroyTime = 4f;

    void Update()
    {
        transform.position += Vector3.left * obstacleSpeed * Time.deltaTime;        // moving obstacle

        Destroy(gameObject, destroyTime);                                           // destory obstacle
    }
}

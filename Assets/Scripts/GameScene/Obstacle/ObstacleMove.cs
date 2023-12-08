using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] float obstacleSpeed = 20f;           // 함정이 플레이어에게 가는 속도
    [SerializeField] float destroyTime = 2f;              // 생성되고 나서 파괴될 시간

    void Update()
    {
        transform.position += Vector3.left * obstacleSpeed * Time.deltaTime;        // 이동

        Destroy(gameObject, destroyTime);                                           // 파괴
    }
}

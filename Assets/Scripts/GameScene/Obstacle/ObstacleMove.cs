using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] float obstacleSpeed = 20f;           // ������ �÷��̾�� ���� �ӵ�
    [SerializeField] float destroyTime = 2f;              // �����ǰ� ���� �ı��� �ð�

    void Update()
    {
        transform.position += Vector3.left * obstacleSpeed * Time.deltaTime;        // �̵�

        Destroy(gameObject, destroyTime);                                           // �ı�
    }
}

using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [HideInInspector] public bool isHit = false;
    [HideInInspector] public bool isScored = false;
    
    [SerializeField] float obstacleSpeed = 20f;           // ������ �÷��̾�� ���� �ӵ�
    [SerializeField] float destroyTime = 2f;              // �����ǰ� ���� �ı��� �ð�

    void Update()
    {
        transform.position += Vector3.left * obstacleSpeed * Time.deltaTime;        // �̵�

        Destroy(gameObject, destroyTime);                                           // �ı�
    }
}

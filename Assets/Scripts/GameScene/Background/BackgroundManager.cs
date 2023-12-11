using UnityEditor.SceneManagement;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] float backgroundSpeed = 20f;           // ����� �������� �ӵ�

    float ScreenHalfSize;                                   // ����ȭ���� ���� ����
    float deletePos;                                        // ����� ����� ��ġ
    float spawnPos;                                         // ����� ��Ÿ�� ��ġ

    int Stage = 0;                                          // ��� �������������� ���� ����

    void Start()
    {
        ScreenHalfSize = Camera.main.orthographicSize * Camera.main.aspect;
        spawnPos = ScreenHalfSize * 2;
        deletePos = -(spawnPos);
    }

    void Update()
    {
        Scrolling();
    }

    void Scrolling()
    {
        transform.position += Vector3.left * backgroundSpeed * Time.deltaTime;       // �̵�

        if (transform.position.x < deletePos * 1.5f)                                        // ����� ��ġ�� ����� ��ġ�� ��������
        {
            transform.position = new Vector3(spawnPos * 2.18f, 0, 0);                        // ����� spawnPos�� �̵�

            setPrefab();                                                             // ���������� ���缭 ������ ����
        }
    }

    void setPrefab()
    {
        switch (Stage)
        {
            case 0:
                Resources.Load<GameObject>("Prefabs/Backgrounds/Background_s0");           // 1�������� ������(�ð�)
                break;
            case 1:
                Resources.Load<GameObject>("Prefabs/Backgrounds/Background_s1");           // 2�������� ������(����)
                break;
        }
    }
}

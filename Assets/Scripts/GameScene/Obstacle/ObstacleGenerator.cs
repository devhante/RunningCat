using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    GameObject ObstaclePrefab;       // ���� ������

    [SerializeField] float spawnTime = 2f;            // ������ �����Ǵ� �ð� ����

    float flowedTime = 0f;                  // �ð��� ���� ����

    int selectType = -1;                    // ������ Ÿ���� �����ϴ� ����
    int Stage = 0;                          // ��� �������������� ���� ����

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        flowedTime += Time.deltaTime;

        if (flowedTime > spawnTime)
        {
            selectType = (Stage == 0) ? Random.Range(0, 2) : Random.Range(2, 4);                                        // Stage�� �´� ���� ������ ���ϱ�

            setPrefab();                                                                                                // selectType�� Stage�� �°� ������ �ε�

            if (ObstaclePrefab) Instantiate(ObstaclePrefab, GameObject.Find("Obstacles").transform);                    // �������� �ε� �Ǿ��� ���� ����

            flowedTime = 0f;                                                                                            // �ð� �ʱ�ȭ
        }
    }

    void setPrefab()
    {
        switch (selectType)
        {
            case 0:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Wood");                // ����
                break;

            case 1:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Bird");                // ��
                break;

            case 2:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Tack");                // �۰�
                break;

            case 3:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Missile");             // �̻���
                break;
        }
    }
}
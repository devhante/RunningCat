using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    GameObject ObstaclePrefab;       // 함정 프리팹

    [SerializeField] float spawnTime = 2f;            // 함정이 스폰되는 시간 간격

    float flowedTime = 0f;                  // 시간이 지난 정도

    int selectType = -1;                    // 함정의 타입을 결정하는 변수
    int Stage = 0;                          // 어느 스테이지인지에 대한 변수

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        flowedTime += Time.deltaTime;

        if (flowedTime > spawnTime)
        {
            selectType = (Stage == 0) ? Random.Range(0, 2) : Random.Range(2, 4);                                        // Stage에 맞는 랜덤 함정을 정하기

            setPrefab();                                                                                                // selectType과 Stage에 맞게 프리팹 로드

            if (ObstaclePrefab) Instantiate(ObstaclePrefab, GameObject.Find("Obstacles").transform);                    // 프리팹이 로드 되었을 때만 생성

            flowedTime = 0f;                                                                                            // 시간 초기화
        }
    }

    void setPrefab()
    {
        switch (selectType)
        {
            case 0:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Wood");                // 나무
                break;

            case 1:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Bird");                // 새
                break;

            case 2:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Tack");                // 송곳
                break;

            case 3:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Missile");             // 미사일
                break;
        }
    }
}
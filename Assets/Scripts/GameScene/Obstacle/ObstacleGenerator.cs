using RunningCat.GameScene;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    GameObject ObstaclePrefab;

    [Tooltip("함정들이 스폰되는 시간 간격")]
    [SerializeField] float spawnTime = 2;

    float flowedTime = 0;

    int selectType = -1;
    int Stage = 0;

    void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        flowedTime += Time.deltaTime;

        if (flowedTime > spawnTime)
        {
            selectType = (Stage == 0) ? Random.Range(0, 2) : Random.Range(2, 4);            // set random obstacle which right stage

            setPrefab();            // load prefab which right stage

            if (ObstaclePrefab) Instantiate(ObstaclePrefab, GameObject.Find("Obstacles").transform);            // if loaded prefab, create obstacle

            spawnTime = Random.Range(0.4f, 3f);         // set random spawntime
            flowedTime = 0f;
        }
    }

    void setPrefab()
    {
        switch (selectType)
        {
            case 0:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Wood");                // tree
                break;

            case 1:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Crow");                // crow
                break;

            case 2:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Tack");                // tack
                break;

            case 3:
                ObstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacles/Missile");             // missile
                break;
        }
    }
}
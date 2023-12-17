using UnityEngine;

public class ChuruGenerator : MonoBehaviour
{
    GameObject ChuruPrefab;

    [Tooltip("�򸣰� �����Ǵ� �ð� ����")]
    [SerializeField] float spawnTime = 2;

    float flowedTime = 2;

    void Awake()
    {
        ChuruPrefab = Resources.Load<GameObject>("Prefabs/Churus/Churu");
    }

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        flowedTime += Time.deltaTime;

        if(flowedTime > spawnTime && ChuruPrefab)
        {
            Instantiate(ChuruPrefab, GameObject.Find("Churus").transform);     // create Churu

            spawnTime = Random.Range(0.4f, 3);          // set random spawntime
            flowedTime = 0;
        }
    }
}

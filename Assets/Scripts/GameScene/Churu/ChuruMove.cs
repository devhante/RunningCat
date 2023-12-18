using System;
using System.Collections;
using RunningCat.GameScene;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChuruMove : MonoBehaviour
{
    [HideInInspector] public bool isHit = false;
    [HideInInspector] public bool isScored = false;

    Transform obstacleTransform;

    [Tooltip("���� ���ǵ�")]
    [SerializeField] float churuSpeed = 1f;
    [Tooltip("���� �ı��Ǵ� �ð� ����")]
    [SerializeField] float destroyTime = 4f;

    void Awake()
    {
        obstacleTransform = GameObject.Find("Obstacles").transform;
        SetChuruPos();
    }

    void Update()
    {
        for(int i = 0; i < obstacleTransform.childCount; i++)
        {
            if (transform.position == obstacleTransform.GetChild(i).position)
                SetChuruPos();
        }

        transform.position += Vector3.left * (churuSpeed + GameManager.instance.speed) * Time.deltaTime;        // moving churu

        Destroy(gameObject, destroyTime);                                           // destory churu
    }

    void SetChuruPos()
    {
        transform.position = new Vector3(1.8f, Random.Range(-0.359f, -0.22f), 0);     //set Churu position
    }
}

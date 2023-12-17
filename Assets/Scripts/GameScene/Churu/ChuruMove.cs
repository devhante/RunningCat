using UnityEngine;

public class ChuruMove : MonoBehaviour
{
    [HideInInspector] public bool isHit = false;
    [HideInInspector] public bool isScored = false;

    Transform obstacleTransform;

    [Tooltip("츄르의 스피드")]
    [SerializeField] float churuSpeed = 1f;
    [Tooltip("츄르이 파괴되는 시간 간격")]
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

        transform.position += Vector3.left * churuSpeed * Time.deltaTime;        // moving churu

        Destroy(gameObject, destroyTime);                                           // destory churu
    }

    void SetChuruPos()
    {
        transform.position = new Vector3(1.8f, Random.Range(-0.359f, -0.22f), 0);     //set Churu position
    }
}

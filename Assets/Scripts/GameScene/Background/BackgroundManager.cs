using UnityEditor.SceneManagement;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] float backgroundSpeed = 20f;           // 배경이 지나가는 속도

    float ScreenHalfSize;                                   // 게임화면의 길이 절반
    float deletePos;                                        // 배경을 사라질 위치
    float spawnPos;                                         // 배경이 나타날 위치

    int Stage = 0;                                          // 어느 스테이지인지에 대한 변수

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
        transform.position += Vector3.left * backgroundSpeed * Time.deltaTime;       // 이동

        if (transform.position.x < deletePos)                                        // 배경의 위치가 사라질 위치를 지나가면
        {
            transform.position = new Vector3(spawnPos, 0, 0);                        // 배경을 spawnPos로 이동

            setPrefab();                                                             // 스테이지에 맞춰서 프리팹 변경
        }
    }

    void setPrefab()
    {
        switch (Stage)
        {
            case 0:
                Resources.Load<GameObject>("Prefabs/Backgrounds/Background_s0");           // 1스테이지 프리팹(시골)
                break;
            case 1:
                Resources.Load<GameObject>("Prefabs/Backgrounds/Background_s1");           // 2스테이지 프리팹(도시)
                break;
        }
    }
}

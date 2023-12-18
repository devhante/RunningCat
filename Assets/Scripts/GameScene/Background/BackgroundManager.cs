using System.Collections;
using RunningCat.GameScene;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] float backgroundSpeed = 20f;           // background speed

    float ScreenHalfSize;           // size of screen (half)
    float deletePos;            // position of delete
    float spawnPos;         // position of spawn

    int Stage = 0;          // number of stage

    void Start()
    {
        ScreenHalfSize = Camera.main.orthographicSize * Camera.main.aspect;
        spawnPos = ScreenHalfSize * 2;
        deletePos = -(spawnPos);
    }

    void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            Scrolling();
        }
    }

    void Scrolling()
    {
        transform.position += Vector3.left * (backgroundSpeed + GameManager.instance.speed) * Time.deltaTime;          // moving background

        if (transform.position.x < deletePos * 1.5f)            // until background position same delete position
        {
            transform.position = new Vector3(spawnPos * 2.18f, 0, 0);           // set background position

            setPrefab();            // load background prefab
        }
    }

    void setPrefab()
    {
        switch (Stage)
        {
            case 0:
                Resources.Load<GameObject>("Prefabs/Backgrounds/Background_s0");            // if stage1, background_s0
                break;
            case 1:
                Resources.Load<GameObject>("Prefabs/Backgrounds/Background_s1");            // if stage2, background_s1
                break;
        }
    }
}

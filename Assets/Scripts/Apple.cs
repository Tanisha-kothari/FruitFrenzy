using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using Random = Unity.Mathematics.Random;

public class Apple : MonoBehaviour
{
    public GameObject goodApples;
    public GameObject badApples;
    GameObject[] arrApples;
    float minSpawnLoc = -7.6f;
    float maxSpawnLoc = 7.04f;
    Random rnd;
    float spawnTimer = 0f;
    public float spawnInterval = 2f;
    public TextMeshProUGUI title, click;
    bool CanStartGame = false;
    void Start()
    {
        arrApples = new GameObject[] { goodApples, badApples };
        rnd = new Random((uint)System.DateTime.Now.Ticks);

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(title);
            Destroy(click);
            CanStartGame = true;
        }
    }

    private void FixedUpdate()
    {
        if (CanStartGame == true)
        {
            Timer();
        }
    }

    void Timer()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnApple();
            spawnTimer = 0f;
        }

    }

    void SpawnApple()
    {
        float spawnLoc = rnd.NextFloat(minSpawnLoc, maxSpawnLoc+1);
        int appleNumber = rnd.NextInt(0, 2);
        GameObject apple = arrApples[appleNumber];
        Vector2 spawnPosition = new Vector2(spawnLoc, transform.position.y);
        Instantiate(apple, spawnPosition, Quaternion.identity);
    }
}

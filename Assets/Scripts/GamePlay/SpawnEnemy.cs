using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JumpFrog;
using UnityEngine;

public class SpawnEnemy : Singleton<SpawnEnemy>
{
    public Transform[] points;
    public GameObject[] enemies;

    public float time = 2, timeCount = 2;

    public int rand, nextRand;

    public float dis = 1;
    public int countSpawn = 0;
    
    public void Spawn()
    {
        countSpawn++;
        rand = Random.Range(0, enemies.Length);
        
        nextRand = Random.Range(0, enemies.Length);

        GameManager.Instance.ShowCurrentImage(rand);
        GameManager.Instance.ShowNextImage(nextRand);

        if (countSpawn >= 3)
        {
            var mainTrans = Camera.main.transform;

            countSpawn = 0;
            mainTrans.DOMoveY(mainTrans.position.y + dis, 0.2f);
        }

        var enemy = Instantiate(enemies[rand]);

        enemy.transform.position = points[Random.Range(0, points.Length)].position;

        enemy.transform.rotation = Quaternion.Euler(Vector3.forward * Random.Range(0, 360));

        var e = enemy.GetComponent<Enemy>();

        if (e)
        {
        }

        enemy.AddComponent<PlayerController>();
    }

    /*void Update()
    {
        if (GameManager.Instance.currentState == State.Playing)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                time = timeCount;

                Spawn();
            }
        }
    }*/
}
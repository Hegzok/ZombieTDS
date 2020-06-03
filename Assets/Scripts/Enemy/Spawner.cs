using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] monsters;

    [SerializeField] private float minSpawnTime, maxSpawnTime, lastTimeSpawned, randomSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnMonster();
    }

    private void SpawnMonster()
    {
        if (Time.time > lastTimeSpawned + randomSpawnTime)
        {
            int randomMonster = Random.Range(0, monsters.Length);
            randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            lastTimeSpawned = Time.time;

            Enemy monster = Instantiate(monsters[randomMonster], this.transform.position, Quaternion.identity);
        }

    }
}

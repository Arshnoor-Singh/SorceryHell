using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject enemyToSpawn;

    /// <summary>
    /// The variable enemySpawnFrequency refers to how many times per second are we going to spawn an enemy
    /// </summary>
    public float enemySpawnFrequency = 1f;
    public float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        spawnTimer = spawnTimer + 0.02f;
        //if (spawnTimer >= enemySpawnFrequency)
        //{
        //    SpawnEnemy();
        //}
    }

    /// <summary>
    /// This functions spawns an enemy prefab at a rate of the given spawn frequency
    /// </summary>
    void SpawnEnemy()
    {

    }
}

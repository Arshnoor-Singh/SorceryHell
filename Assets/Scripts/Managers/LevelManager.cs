using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public Transform player;
    public GameObject enemyToSpawn;

    private Vector3 enemySpawnPosition;

    private float actualSpawnRadius;
    private float actualSpawnAngle;
    public float maxSpawnRadius;
    public float minSpawnRadius;
    
    private GameObject spawnedEnemy;
    /// <summary>
    /// The variable enemySpawnFrequency refers to how many times per second are we going to spawn an enemy
    /// </summary>
    public float enemySpawnFrequency = 1f;  
    public float spawnTimer = 0f;

    private int score;

    public ParticleSystem bloodParticlesPrefab;
    private ParticleSystem spawnedBloodParticleSysytem;

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        spawnedBloodParticleSysytem = Instantiate(bloodParticlesPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if(score>100)
        {
            enemySpawnFrequency = 0.2f;
        }
    }

    private void FixedUpdate()
    {
        spawnTimer = spawnTimer + 0.02f;
        if (spawnTimer >= enemySpawnFrequency)
        {
            spawnTimer = 0;
            SpawnEnemy();
        }
    }

    /// <summary>
    /// This functions spawns an enemy prefab at a rate of the given spawn frequency
    /// </summary>
    void SpawnEnemy()
    {
        actualSpawnRadius = Random.Range(minSpawnRadius, maxSpawnRadius);
        //Debug.Log("Radius = " + actualSpawnRadius);
        actualSpawnAngle = Random.Range(0, 360);
        //Debug.Log("angle = " + actualSpawnAngle);

        enemySpawnPosition = new Vector3(actualSpawnRadius * Mathf.Cos(actualSpawnAngle), 0f, actualSpawnRadius * Mathf.Sin(actualSpawnAngle));

        spawnedEnemy = Instantiate(enemyToSpawn, enemySpawnPosition, Quaternion.identity);
        spawnedEnemy.GetComponent<EnemyBase>().targetPlayer = player;
    }

    public void SpawnBloodParticleAtLocation(Vector3 Location)
    {
        Debug.Log("Request received to spawn a particle at location = " + Location);
        
        EmitParams bloodEmitParams = new EmitParams();
        bloodEmitParams.position = Location;

        spawnedBloodParticleSysytem.Emit(bloodEmitParams, 2);
    }
}

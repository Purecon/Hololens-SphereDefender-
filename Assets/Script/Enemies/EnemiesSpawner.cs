using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemiesSpawner : MonoBehaviour
{
    [Header("Enemies")]
    //enemies->waves->prefab+amount
    public List<EnemySpawnerSO> enemies;
    public List<GameObject> spawnedEnemies;

    [Header("Spawner")]
    public SphereCollider sphereCol;
    private float r;
    public float spawnBetweenWaves = 5;
    public int spawnBetweenSubWaves = 3;
    private float timer = 0;
    private int lastSpawnedIndex = 0;
    private int lastSpawnedSubIndex = 0;
    private bool noMoreSpawn = false;

    public AudioSource audioStart;
    public AudioSource audioEnd;

    [Header("Bool for game")]
    public bool gameStarted = false;

    //Event
    public event Action onGameFinished;

    private void Start()
    {
        r = sphereCol.radius;
        spawnedEnemies = new List<GameObject>();

        Debug.Log("r: " + r);

        timer = spawnBetweenWaves;
        //Spawn Each Wave Individually
        //SpawnEnemies(0);
    }

    private void Update()
    {
        if (gameStarted)
        {
            timer += Time.deltaTime;

            //Spawn Each Wave Individually
            if (timer > spawnBetweenWaves)
            {
                if (lastSpawnedIndex <= enemies.Count - 1)
                {
                    //Garbage collection
                    spawnedEnemies.RemoveAll(s => s == null);

                    //Spawn
                    if (!noMoreSpawn)
                    {
                        SpawnEnemies(lastSpawnedIndex, lastSpawnedSubIndex);
                    }

                    if (lastSpawnedSubIndex < enemies[lastSpawnedIndex].waves.Count - 1)
                    {
                        //Next subwave
                        lastSpawnedSubIndex++;
                        Debug.LogFormat("Increment {0}-{1}", lastSpawnedIndex + 1, lastSpawnedSubIndex + 1);
                    }
                    else
                    {
                        //Next wave
                        if (spawnedEnemies.Count == 0)
                        {
                            if (lastSpawnedIndex == enemies.Count - 1)
                            {
                                gameStarted = false;
                                onGameFinished();
                                audioEnd.Play();
                                Debug.Log("All waves cleared!");
                            }
                            else
                            {
                                lastSpawnedIndex++;
                                lastSpawnedSubIndex = 0;
                                noMoreSpawn = false;
                                //Next wave sound
                                audioStart.Play();
                                Debug.LogFormat("Now entering wave: {0}", lastSpawnedIndex + 1);
                            }
                        }
                        //Masih ada musuh
                        else
                        {
                            noMoreSpawn = true;
                        }
                    }
                }
                if (!noMoreSpawn)
                {
                    timer = 0;
                }
            }
        }
    }

    public void SpawnEnemies(int index, int subWaveIndex)
    {
        Debug.LogFormat("Spawn {0}-{1}",index+1,subWaveIndex+1);
        EnemyWaveSO enemy = enemies[index].waves[subWaveIndex];
        StartCoroutine(SpawnUnit(enemy, spawnBetweenSubWaves));
    }

    /*
    public void SpawnEnemies(int index)
    {
        foreach (EnemyWaveSO enemy in enemies[index].waves)
        {
            StartCoroutine(SpawnUnit(enemy,spawnBetweenSubWaves));
        }
    }
    */

    public void StartGame()
    {
        //timer = 0;
        lastSpawnedIndex = 0;
        lastSpawnedSubIndex = 0;
        noMoreSpawn = false;
        gameStarted = true;
        audioStart.Play();
    }

    //Coroutine
    IEnumerator SpawnUnit(EnemyWaveSO enemy, int secondsWait)
    {
        for (int i = 0; i < enemy.enemyAmount; i++)
        {
            GameObject spawned = Instantiate(enemy.enemyPrefab, transform);

            float x = UnityEngine.Random.Range(-1f, 1f);
            float y = UnityEngine.Random.Range(-1f, 1f);
            float z = UnityEngine.Random.Range(-1f, 1f);

            Vector3 spawnVector = new Vector3(x, y, z).normalized * r;
            //Vector3 spawnVector = Random.onUnitSphere;
            spawnVector += transform.position;
            //Debug.Log(spawnVector.ToString());
            //spawned.transform.SetParent(transform, false);
            if (enemy.isTutorial)
            {
                spawned.transform.position = transform.position;
            }
            else
            {
                spawned.transform.position = spawnVector;
            }
            spawnedEnemies.Add(spawned);

            yield return new WaitForSeconds(secondsWait);
        }
    }
}

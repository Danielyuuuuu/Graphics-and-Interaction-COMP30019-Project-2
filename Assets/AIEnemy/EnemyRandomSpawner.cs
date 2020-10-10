using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
  public Transform[] spawnPoints;
  public GameObject[] enemyPrefabs;
  private bool stopSpawning = false;
  public float startSpawnTime = 2f;
  public float spawnDelay = 0.5f;
  private bool firstSpawnDone = false;
  private float firstSpawnTime;
  public float totalSpawnTime = 1000f;

  private int startChildCount;
  private int currentEnemyCount = 0;
  private int numOfEnemySpawned = 0;

  public void Start()
  {
    InvokeRepeating("SpawnObject", startSpawnTime, spawnDelay);
    startChildCount = this.transform.childCount;
  }

  public void SpawnObject()
  {
    if (!firstSpawnDone)
    {
      firstSpawnTime = Time.time;
      firstSpawnDone = true;
    }

    int randSpawnPoint = Random.Range(0, spawnPoints.Length);
    GameObject enemy = Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
    enemy.transform.parent = this.transform;

    numOfEnemySpawned++;

    if ((Time.time - firstSpawnTime) > totalSpawnTime)
    {
      CancelInvoke("SpawnObject");
    }
  }

  private void Update()
  {
    currentEnemyCount = this.transform.childCount - startChildCount;
    Debug.Log("Current enemy count: " + currentEnemyCount);
    Debug.Log("numOfEnemySpawned: " + numOfEnemySpawned);
  }

}

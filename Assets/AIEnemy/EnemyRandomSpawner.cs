using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
  public Transform[] spawnPoints;
  public GameObject[] enemyPrefabs;
  private bool stopSpawning = false;
  private float spawnTime = 2f;
  private float spawnDelay = 0.5f;
  private bool firstSpawnDone = false;
  private float firstSpawnTime;
  private float totalSpawnTime = 10f;

  public void Start()
  {
    InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
  }

  public void SpawnObject()
  {
    if (!firstSpawnDone)
    {
      firstSpawnTime = Time.time;
      firstSpawnDone = true;
    }

    int randSpawnPoint = Random.Range(0, spawnPoints.Length);
    Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
    if ((Time.time - firstSpawnTime) > totalSpawnTime)
    {
      CancelInvoke("SpawnObject");
    }
  }

  /*
  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      int randEnemy = Random.Range(0, enemyPrefabs.Length);
      int randSpawnPoint = Random.Range(0, spawnPoints.Length);

      Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
    }
  }
    */

}

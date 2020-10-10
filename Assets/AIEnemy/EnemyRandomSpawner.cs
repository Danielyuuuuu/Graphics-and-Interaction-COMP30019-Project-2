using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
  public Transform[] spawnPoints;
  public GameObject[] enemyPrefabs;
  private bool stopSpawning = false;
  public float spawnTime = 2f;
  public float spawnDelay = 0.5f;
  private bool firstSpawnDone = false;
  private float firstSpawnTime;
  public float totalSpawnTime = 1000f;

  private int startChildCount;

  public void Start()
  {
    InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
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
    if ((Time.time - firstSpawnTime) > totalSpawnTime)
    {
      CancelInvoke("SpawnObject");
    }
  }

  private void Update()
  {
    Debug.Log(this.transform.childCount - startChildCount);
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

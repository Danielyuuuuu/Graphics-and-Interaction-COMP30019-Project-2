using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
  public Transform[] spawnPoints;
  public GameObject[] enemyPrefabs;
  private bool stopSpawning = false;
  public float startSpawnTime = 0f;
  public float spawnDelay = 0.5f;
  private bool firstSpawnDone = false;
  private float firstSpawnTime;
  public float levelSpawnTime = 20f;
  public float levelSurvivalTimeNeeded = 30f;

  private int startChildCount;
  private int currentEnemyCount = 0;
  private int numOfEnemySpawned = 0;

  private int currentLevel;

  public void Start()
  {
    startChildCount = this.transform.childCount;
    startLevel();
  }

  public void startLevel()
  {
    currentLevel = 1;
    Debug.Log("Start level!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    InvokeRepeating("SpawnObject", startSpawnTime, spawnDelay);
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

    if ((Time.time - firstSpawnTime) > levelSpawnTime)
    {
      CancelInvoke("SpawnObject");
    }
  }

  public void nextLevel()
  {
    spawnDelay *= 0.8f;
    levelSpawnTime *= 1.2f;
    currentLevel++;
    Debug.Log("Next level!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    InvokeRepeating("SpawnObject", startSpawnTime, spawnDelay);
  }

  private void Update()
  {
    currentEnemyCount = this.transform.childCount - startChildCount;
    Debug.Log("Current enemy count: " + currentEnemyCount);
    Debug.Log("numOfEnemySpawned: " + numOfEnemySpawned);

    if (firstSpawnDone && (Time.time - firstSpawnTime) >= levelSurvivalTimeNeeded)
    {
      CancelInvoke("SpawnObject");
      firstSpawnDone = false;
      foreach (Transform child in transform)
      {
        if(child.gameObject.tag == "Enemy")
        {
          Destroy(child.gameObject);
        }
        
      }
      nextLevel();
    }
  }

}

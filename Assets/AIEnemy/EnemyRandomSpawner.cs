using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
  public Transform[] spawnPoints;
  public GameObject[] enemyPrefabs;

  public void Start()
  {

  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      int randEnemy = Random.Range(0, enemyPrefabs.Length);
      int randSpawnPoint = Random.Range(0, spawnPoints.Length);

      Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
    }
  }
}

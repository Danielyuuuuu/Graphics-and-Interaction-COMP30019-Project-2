using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyRandomSpawner : MonoBehaviour
{
  public Transform[] spawnPoints;
  public GameObject[] enemyPrefabs;
  private bool stopSpawning = false;
  public float startSpawnTime = 0f;
  public float spawnDelay = 0.5f;
  private bool firstSpawnDone = false;
  private float firstSpawnTime;
  public float levelSurvivalTimeNeeded = 30f;
  public int finalLevel = 5;

  private int startChildCount;
  private int currentEnemyCount = 0;
  private int numOfEnemySpawned = 0;

  private int currentLevel;

  public UITextManager uiTextManager;

  public UnityEvent gameWonEvent;

  private HealthManager player;

  public int maxNumberOfEnemy;

  private Boolean calledPopUpMessage = false;

  public void Start()
  {
    startChildCount = this.transform.childCount;
    startLevel();
    player = PlayerManager.instance.player.GetComponent<HealthManager>();
  }

  public void startLevel()
  {
    currentLevel = 1;
    this.uiTextManager.currentLevel = this.currentLevel;
    InvokeRepeating("SpawnObject", startSpawnTime, spawnDelay);
  }

  public void SpawnObject()
  {
    if (!firstSpawnDone)
    {
      firstSpawnTime = Time.time;
      firstSpawnDone = true;
    }

    if (currentEnemyCount < maxNumberOfEnemy)
    {
      int randSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
      GameObject enemy = Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
      enemy.transform.parent = this.transform;

      numOfEnemySpawned++;

      if ((Time.time - firstSpawnTime) > levelSurvivalTimeNeeded)
      {
        CancelInvoke("SpawnObject");
      }
    }
    else
    {
      Debug.Log("Max number of enemy in the map reached.......");
    }
  }

  public void nextLevel()
  {
    spawnDelay *= 0.8f;
    maxNumberOfEnemy = (int)(maxNumberOfEnemy * 1.2f);
    enemyPrefabs[0].GetComponent<EnemyController>().randomShooting *= 1.3f;
    Debug.Log("New randomShooting: " + enemyPrefabs[0].GetComponent<EnemyController>().randomShooting);
    currentLevel++;
    this.uiTextManager.currentLevel = this.currentLevel;
    InvokeRepeating("SpawnObject", startSpawnTime, spawnDelay);
    StartCoroutine(PopUpLevelUpMessage());
  }

  IEnumerator PopUpLevelUpMessage()
  {
    PopUpMessage.ShowPopUpMessage_Static("Level Up!");
    yield return new WaitForSeconds(5);
    PopUpMessage.HidePopUpMessage_Static();
  }


  private void Update()
  {
    currentEnemyCount = this.transform.childCount - startChildCount;

    if (player.GetHealth() > 0.0f)
    {

      if (firstSpawnDone && (Time.time - firstSpawnTime) >= levelSurvivalTimeNeeded)
      {
        this.uiTextManager.levelTimeRemaining = 0;
      }
      else if (firstSpawnDone)
      {
        this.uiTextManager.levelTimeRemaining = (int)(levelSurvivalTimeNeeded - (Time.time - firstSpawnTime));
      }
      else
      {
        this.uiTextManager.levelTimeRemaining = (int)levelSurvivalTimeNeeded;
      }

      if (firstSpawnDone && (Time.time - firstSpawnTime) >= levelSurvivalTimeNeeded)
      {
        CancelInvoke("SpawnObject");
        //KillAllEnemies();


        if (currentEnemyCount <= 0)
        {
          calledPopUpMessage = false;
          if (currentLevel == finalLevel)
          {
            this.gameWonEvent.Invoke();
          }
          else
          {
            firstSpawnDone = false;
            PopUpMessage.HidePopUpMessage_Static();
            nextLevel();
          }  
        }
        else
        {
          //PopUpMessage.ShowPopUpMessage_Static("Enemy stopped spawning, kill the remaining enemies!");
          if (!calledPopUpMessage)
          {
            StartCoroutine(PopUpToKillRemainingEnemiesMessage());
            calledPopUpMessage = true;
          }
       
        }
      }
      
    }
  }

  IEnumerator PopUpToKillRemainingEnemiesMessage()
  {
    PopUpMessage.ShowPopUpMessage_Static("Enemy stopped spawning, kill the remaining enemies!");
    yield return new WaitForSeconds(5);
    PopUpMessage.HidePopUpMessage_Static();
  }

  public void KillAllEnemies()
  {
    foreach (Transform child in transform)
    {
      if (child.gameObject.tag == "Enemy")
      {
        Destroy(child.gameObject);
      }

    }
  }

}

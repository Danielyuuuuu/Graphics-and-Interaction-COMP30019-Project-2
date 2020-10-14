using UnityEngine;
using System.Collections;

public class IncreaseScoreOnDestroy : MonoBehaviour
{

  public int storeCreditIncrementAmount;
  public ScoreManager scoreManager;


  void Start()
  {
    // Find score manager by tag, if not referenced already
    if (scoreManager == null)
    {
      this.scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }
  }

  // Increment player score when destroyed
  void OnDestroy()
  {
    this.scoreManager.enemyKilled += 1;
    this.scoreManager.storeCredit += this.storeCreditIncrementAmount;
  }
}

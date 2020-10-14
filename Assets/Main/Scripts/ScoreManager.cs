using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
  
  public int enemyKilled = 0;
  public int storeCredit = 0;

  public void ResetScore()
  {
    this.enemyKilled = 0;
    this.storeCredit = 0;
  }
}
using UnityEngine;
using System.Collections;

public class UITextManager : MonoBehaviour
{

  public int enemyKilled = 0;
  public int storeCredit = 0;
  public int levelTimeRemaining = 0;
  public int currentLevel = 0;

  public void ResetScore()
  {
    this.enemyKilled = 0;
    this.storeCredit = 0;
    this.levelTimeRemaining = 0;
    this.currentLevel = 0;
}
}
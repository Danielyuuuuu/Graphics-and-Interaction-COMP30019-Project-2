using UnityEngine;
using System.Collections;

public class UITextManager : MonoBehaviour
{

  public int enemyKilled = 0;
  public int storeCredit = 0;
  public int levelTimeRemaining = 0;
  public int currentLevel = 0;
  public Transform gameEndButton;
  public Transform gameWon;
  public Transform gameOver;

  public void Start()
  {
    this.enemyKilled = 0;
    this.storeCredit = 0;
    this.levelTimeRemaining = 0;
    this.currentLevel = 0;
    gameEndButton.gameObject.SetActive(false);
    gameWon.gameObject.SetActive(false);
    gameOver.gameObject.SetActive(false);
  }

  public void ResetScore()
  {
    this.enemyKilled = 0;
    this.storeCredit = 0;
    this.levelTimeRemaining = 0;
    this.currentLevel = 0;
    gameEndButton.gameObject.SetActive(false);
  }

  public void SetGameOverUI()
  {
    gameEndButton.gameObject.SetActive(true);
    gameOver.gameObject.SetActive(true);
  }

  public void SetGameWonUI()
  {
    gameEndButton.gameObject.SetActive(true);
    gameWon.gameObject.SetActive(true);
  }

}
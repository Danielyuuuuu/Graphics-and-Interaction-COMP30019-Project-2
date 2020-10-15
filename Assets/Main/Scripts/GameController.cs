using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
  public Text enemyKilled;
  public Text storeCredit;
  public Text levelTimeRemaining;
  public Text currentLevel;

  public UITextManager uiTextManager;

  public static bool lastGameWon;

  // Start is called before the first frame update
  void Start()
  {
    this.uiTextManager.enemyKilled = 0;
    this.uiTextManager.storeCredit = 0;
    this.uiTextManager.levelTimeRemaining = 0;
    this.uiTextManager.currentLevel = 0;
  }

  // Update is called once per frame
  void Update()
  {
    // Update score text field
    this.enemyKilled.text = "Enemy Killed: " + this.uiTextManager.enemyKilled;
    this.storeCredit.text = "Store Credit: " + this.uiTextManager.storeCredit;
    this.levelTimeRemaining.text = "Level Time Remaining: " + this.uiTextManager.levelTimeRemaining;
    this.currentLevel.text = "Current Level: " + this.uiTextManager.currentLevel;
  }

  public void GameOver()
  {
    GameController.lastGameWon = false;
    SceneManager.LoadScene("GameEndScene");
  }

  public void PlayerWon()
  {
    GameController.lastGameWon = true;
    SceneManager.LoadScene("GameEndScene");
  }
}

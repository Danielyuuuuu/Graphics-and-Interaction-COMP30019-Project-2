using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
  public Text enemyKilled;
  public Text storeCredit;

  public ScoreManager scoreManager;

  public static bool lastGameWon;

  // Start is called before the first frame update
  void Start()
  {
    this.scoreManager.enemyKilled = 0;
    this.scoreManager.storeCredit = 0;
  }

  // Update is called once per frame
  void Update()
  {
    // Update score text field
    this.enemyKilled.text = "Enemy Killed: " + this.scoreManager.enemyKilled;
    this.storeCredit.text = "Store Credit: " + this.scoreManager.storeCredit;
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

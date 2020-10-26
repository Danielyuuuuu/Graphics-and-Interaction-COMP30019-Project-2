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
  public Text playerHealth;
  public Text bulletText;

  public UITextManager uiTextManager;

  public static bool lastGameWon;

  private HealthManager player;
  private IWeaponMechanic playerWeapon;

    // Start is called before the first frame update
    void Start()
  {
    this.uiTextManager.enemyKilled = 0;
    this.uiTextManager.storeCredit = 0;
    this.uiTextManager.levelTimeRemaining = 0;
    this.uiTextManager.currentLevel = 0;

    player = PlayerManager.instance.player.GetComponent<HealthManager>();

    Transform[] childs = PlayerManager.instance.player.GetComponentsInChildren<Transform>();
    foreach (Transform t in childs)
    {
      if (t.gameObject.name == "Weapon")
      {
        //weapon = t.GetComponentInChildren<IWeaponMechanic>();

        foreach (Transform child in t)
        {
          if (child.gameObject.activeSelf)
          {
            playerWeapon = t.GetComponentInChildren<IWeaponMechanic>();
            break;
          }
        }
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
    // Update score text field
    this.enemyKilled.text = "Enemy Killed: " + this.uiTextManager.enemyKilled;
    this.storeCredit.text = "Store Credit: " + this.uiTextManager.storeCredit;
    this.levelTimeRemaining.text = "Level Time Remaining: " + this.uiTextManager.levelTimeRemaining;
    this.currentLevel.text = "Current Level: " + this.uiTextManager.currentLevel;
    int healthPercentage = (int) (((player.GetHealth() * 1.0f) / (player.startingHealth * 1.0f)) * 100.0f);
    this.playerHealth.text = "Health: " + healthPercentage + "%";
    this.bulletText.text = "30/180";
  }

  public void GameOver()
  {
    GameController.lastGameWon = false;
    //Invoke("LoadGameEndScene", 10);
  }

  /*
  public void LoadGameEndScene()
  {
    SceneManager.LoadScene("GameEndScene");
  }
  */

  public void ReturnToMainMenu()
  {
    SceneManager.LoadScene("StartMenu");
  }

  public void PlayerWon()
  {
    GameController.lastGameWon = true;
    SceneManager.LoadScene("GameEndScene");
  }
}

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
  public Text weaponName;
  public UITextManager uiTextManager;

  public static bool lastGameWon;

  private HealthManager player;
  private IWeaponMechanic playerWeapon;

  private bool displayBuyWeaponMessage = true;

  public GameObject canvas;

  // Start is called before the first frame update
  void Start()
  {
    this.uiTextManager.enemyKilled = 0;
    this.uiTextManager.storeCredit = 0;
    this.uiTextManager.levelTimeRemaining = 0;
    this.uiTextManager.currentLevel = 0;

    player = PlayerManager.instance.player.GetComponent<HealthManager>();
    GetPlayerWeapon();

    canvas = GameObject.FindGameObjectWithTag("Canvas");
  }

  // Update is called once per frame
  void Update()
  {
    GetPlayerWeapon();
    // Update score text field
    this.enemyKilled.text = "Enemy Killed: " + this.uiTextManager.enemyKilled;
    this.storeCredit.text = "Store Credit: " + this.uiTextManager.storeCredit;
    this.levelTimeRemaining.text = "Level Time Remaining: " + this.uiTextManager.levelTimeRemaining;
    this.currentLevel.text = "Current Level: " + this.uiTextManager.currentLevel;
    int healthPercentage = (int) (((player.GetHealth() * 1.0f) / (player.startingHealth * 1.0f)) * 100.0f);
    this.playerHealth.text = "Health: " + healthPercentage + "%";
    if(playerWeapon.GetWeaponName() == "Revolver")
    {
      this.bulletText.text = playerWeapon.GetBulletRamainingInTheMagazine().ToString() + "/" + "inf";
    }
    else
    {
      this.bulletText.text = playerWeapon.GetBulletRamainingInTheMagazine().ToString() + "/" + playerWeapon.GetBulletRamainingInTheBackupBullet().ToString();
    }
    this.weaponName.text = playerWeapon.GetWeaponName();

    if(displayBuyWeaponMessage && uiTextManager.storeCredit >= 150)
    {
      StartCoroutine(BuyWeaponMessage());
      displayBuyWeaponMessage = false;
    }
  }

  public void GetPlayerWeapon()
  {
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

  public void PauseGame()
  {
    Time.timeScale = 0;
    uiTextManager.StopDisplayingUI();
    foreach (Transform child in canvas.transform)
    {
      if (child.tag == "PauseScene")
      {
        child.gameObject.SetActive(true);
        break;
      }
    }
  }

  public void ResumeGame()
  {
    Time.timeScale = 1;
    uiTextManager.StopDisplayingUI();
    foreach (Transform child in canvas.transform)
    {
      if (child.tag == "BasicUIText")
      {
        child.gameObject.SetActive(true);
      }
    }
  }

  IEnumerator BuyWeaponMessage()
  {
    PopUpMessage.ShowPopUpMessage_Static("You can buy weapons in the yellow military tent, \n which is located in the middle left of the map");
    Time.timeScale = 0.2f;
    Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
    yield return new WaitForSeconds(1f);
    PopUpMessage.HidePopUpMessage_Static();
    Time.fixedDeltaTime = Time.fixedDeltaTime / Time.timeScale;
    Time.timeScale = 1;
  }
}

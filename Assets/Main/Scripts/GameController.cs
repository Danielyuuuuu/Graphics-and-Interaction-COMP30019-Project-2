using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
  public Text scoreText;
  public Text healthText;

  public ScoreManager scoreManager;

  // Start is called before the first frame update
  void Start()
  {
    this.scoreManager.score = 0;
  }

  // Update is called once per frame
  void Update()
  {
    // Update score text field
    this.scoreText.text = "Score: " + this.scoreManager.score;
  }
}

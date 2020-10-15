using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndsController : MonoBehaviour
{

  public Text resultText;


  void Start()
  {

    
    // Display text based on last game result
    if (GameController.lastGameWon)
    {
      this.resultText.text = "You Won!";
    }
    else
    {
      this.resultText.text = "You Lost!";
    }

    //this.resultText.text = "You Lost!";
  }

  public void OnBackButtonPressed()
  {
    SceneManager.LoadScene("MainMenu");
  }
}

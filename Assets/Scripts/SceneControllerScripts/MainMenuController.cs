using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

  public void StartGame()
  {
    SceneManager.LoadScene("InGame");
  }

  public void OpenInstructions()
  {
    SceneManager.LoadScene("Instructions");
  }

  public void OpenOptions()
  {
    SceneManager.LoadScene("Options");
  }
}

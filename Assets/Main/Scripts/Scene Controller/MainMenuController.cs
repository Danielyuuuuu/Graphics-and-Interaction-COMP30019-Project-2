using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

  public void StartGame()
  {
    SceneManager.LoadScene("MainGameScene");
  }

  public void OpenInstructions()
  {
    SceneManager.LoadScene("InstructionsScene");
  }

  public void OpenOptions()
  {
    SceneManager.LoadScene("OptionsScene");
  }
}

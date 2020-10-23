using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionsController : MonoBehaviour
{

  public void BackToMainMenu()
  {
    SceneManager.LoadScene("StartMenu");
  }
}

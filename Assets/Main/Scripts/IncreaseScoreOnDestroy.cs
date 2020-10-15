using UnityEngine;
using System.Collections;

public class IncreaseScoreOnDestroy : MonoBehaviour
{

  public int storeCreditIncrementAmount;
  public UITextManager uiTextManager;


  void Start()
  {
    // Find score manager by tag, if not referenced already
    if (uiTextManager == null)
    {
      this.uiTextManager = GameObject.FindGameObjectWithTag("UITextManager").GetComponent<UITextManager>();
    }
  }

  // Increment player score when destroyed
  void OnDestroy()
  {
    this.uiTextManager.enemyKilled += 1;
    this.uiTextManager.storeCredit += this.storeCreditIncrementAmount;
  }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour
{
  private static PopUpMessage instance;

  private Text uiText;
  private RectTransform backgroundRectTransform;

  public new Camera camera;

  private void Awake()
  {
    instance = this;
    backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
    uiText = transform.Find("Text").GetComponent<Text>();

    ShowPopUpMessage("Random PopUpMessage text");
  }

  public void Start()
  {
    gameObject.SetActive(false);
  }

  private void Update()
  {
    //transform.localPosition = new Vector2(Input.mousePosition.x - 780, Input.mousePosition.y - 480);
  }

  private void ShowPopUpMessage(string inputText)
  {
    gameObject.SetActive(true);
    Debug.Log("Set active to true......");

    uiText.text = inputText;
    float textPaddingSize = 8f;
    Vector2 backgroundSize = new Vector2(uiText.preferredWidth + textPaddingSize, uiText.preferredHeight + textPaddingSize);
    backgroundRectTransform.sizeDelta = backgroundSize;
  }

  private void HidePopUpMessage()
  {
    gameObject.SetActive(false);
  }

  public static void ShowPopUpMessage_Static(string inputText)
  {
    instance.ShowPopUpMessage(inputText);
  }

  public static void HidePopUpMessage_Static()
  {
    instance.HidePopUpMessage();
  }
}

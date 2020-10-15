using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
  private static Tooltip instance;

  private Text uiText;
  private RectTransform backgroundRectTransform;

  public new Camera camera;

  private void Awake()
  {
    instance = this;
    backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
    uiText = transform.Find("Text").GetComponent<Text>();

    ShowTooltip("Random tooltip text");
    Debug.Log("ShowTooltip();");
  }

  private void Update()
  {
    transform.localPosition = new Vector2(Input.mousePosition.x - 385, Input.mousePosition.y - 235);
  }

  private void ShowTooltip(string inputText)
  {
    gameObject.SetActive(true);

    uiText.text = inputText;
    float textPaddingSize = 8f;
    Vector2 backgroundSize = new Vector2(uiText.preferredWidth + textPaddingSize, uiText.preferredHeight + textPaddingSize);
    backgroundRectTransform.sizeDelta = backgroundSize;
  }

  private void HideTooltip()
  {
    gameObject.SetActive(false);
  }

  public static void ShowTooltip_Static(string inputText)
  {
    instance.ShowTooltip(inputText);
  }

  public static void HideTooltip_Static()
  {
    instance.HideTooltip();
  }
}

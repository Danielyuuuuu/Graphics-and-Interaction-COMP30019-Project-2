using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShop : MonoBehaviour
{
  private Transform container;
  private Transform shopItemTemplate;

  private void Awake()
  {
    container = transform.Find("container");
    shopItemTemplate = container.Find("test");
    //shopItemTemplate.gameObject.SetActive(false);
  }

  private void Start()
  {
    CreateItemButton("Item 1", 15, 0);
    CreateItemButton("Item 2", 30, 1);

    Hide();
  }

  /*
  private void CreateItemButton(string itemName, int itemCost, int positionIndex)
  {
    Transform shopItemTransform = Instantiate(shopItemTemplate, container);
    RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

    float shopItemHeight = 70f;
    shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

    shopItemTransform.Find("itemNameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
    shopItemTransform.Find("itemCostText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

    shopItemTransform.gameObject.SetActive(true);
  }
  */
  private void CreateItemButton(string itemName, int itemCost, int positionIndex)
  {
    Transform shopItemTransform = Instantiate(shopItemTemplate, container);
    RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

    float shopItemHeight = 70f;
    shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

    shopItemTransform.Find("Button").Find("itemNameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
    shopItemTransform.Find("Button").Find("itemCostText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

    Button btn = shopItemTransform.Find("Button").GetComponent<Button>();
    btn.onClick.AddListener(TaskOnClick);

    shopItemTransform.gameObject.SetActive(true);
  }

  void TaskOnClick()
  {
    Debug.Log("You have clicked the button!");
  }

  public void Show(GameObject player)
  {
    gameObject.SetActive(true);
  }

  public void Hide()
  {
    gameObject.SetActive(false);
  }
}

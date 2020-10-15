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
    shopItemTemplate = container.Find("shopItemTemplate");
    //shopItemTemplate.gameObject.SetActive(false);
  }

  private void Start()
  {
    CreateItemButton("Item 1", 15, 0);
    CreateItemButton("Item 2", 30, 1);
  }

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
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIShop : MonoBehaviour
{
  private Transform container;
  private Transform shopItemTemplate;

  public UITextManager uiTextManager;

  private void Awake()
  {
    container = transform.Find("container");
    shopItemTemplate = container.Find("shopItemTemplate");

  }

  private void Start()
  {
    CreateItemButton("Health Pack", 300, 0);
    CreateItemButton("Uzi", -1, 1);
    CreateItemButton("Rifle", 200, 2);
    CreateItemButton("Shotgun", 250, 3);
    CreateItemButton("RPG7", 300, 4);

    Hide();
  }

  public void Update()
  {
    if (!EventSystem.current.IsPointerOverGameObject())
    {
      PopUpMessage.HidePopUpMessage_Static();
    }
  }

  private void CreateItemButton(string itemName, int itemCost, int positionIndex)
  {
    Transform shopItemTransform = Instantiate(shopItemTemplate, container);
    RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

    float shopItemHeight = 70f;
    shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

    shopItemTransform.Find("Button").Find("itemNameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
    shopItemTransform.Find("Button").Find("itemCostText").GetComponent<TextMeshProUGUI>().SetText("$" + itemCost.ToString());

    Button btn = shopItemTransform.Find("Button").GetComponent<Button>();
    btn.onClick.AddListener(delegate { TaskOnClick(itemName, itemCost); });

    shopItemTransform.gameObject.SetActive(true);

  }

  void TaskOnClick(string itemName, int itemCost)
  {
    Debug.Log("You have clicked the button: " + itemName);

    if(itemCost <= uiTextManager.storeCredit)
    {
      Debug.Log("Has enough money to buy the item.");
      uiTextManager.storeCredit = uiTextManager.storeCredit - itemCost;
      PlayerManager.instance.player.GetComponent<IKHandling>().EquipStoreItem(itemName);
      PopUpMessage.ShowPopUpMessage_Static("Buy Success");
      //StartCoroutine(BuySuccessMessage());
    }
    else
    {
      Debug.Log("Insufficient fund..............");
      PopUpMessage.ShowPopUpMessage_Static("Insufficient Fund");
      //StartCoroutine(InsufficientFundMessage());
    }
  }

  public void Show(GameObject player)
  {
    gameObject.SetActive(true);
  }

  public void Hide()
  {
    gameObject.SetActive(false);
  }

  IEnumerator BuySuccessMessage()
  {
    PopUpMessage.ShowPopUpMessage_Static("Buy Success");
    yield return new WaitForSeconds(1.5f);
    PopUpMessage.HidePopUpMessage_Static();
  }

  IEnumerator InsufficientFundMessage()
  {
    PopUpMessage.ShowPopUpMessage_Static("Insufficient Fund");
    yield return new WaitForSeconds(1.5f);
    PopUpMessage.HidePopUpMessage_Static();
  }

  public bool isActive()
  {
    return gameObject.activeSelf;
  }
}

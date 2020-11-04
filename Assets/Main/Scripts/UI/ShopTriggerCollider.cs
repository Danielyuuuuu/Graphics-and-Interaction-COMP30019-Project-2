using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
  [SerializeField] private UIShop uiShop;
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      uiShop.Show(other.gameObject);
      Debug.Log("Show shop!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
      Time.timeScale = 0.2f;
      Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
    }

  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      uiShop.Hide();
      PopUpMessage.HidePopUpMessage_Static();
      Debug.Log("Hide shop!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
      Time.fixedDeltaTime = Time.fixedDeltaTime / Time.timeScale;
      Time.timeScale = 1;
    }
  }
}

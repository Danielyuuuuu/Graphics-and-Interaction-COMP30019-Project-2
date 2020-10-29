using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHandling : MonoBehaviour
{
    Animator animator;

    public float LeftHandWeight = 1;
    public Transform LeftHandTarget;

    public float RightHandWeight = 1;
    public Transform RightHandTarget;

    public Transform weapon;
    public Vector3 lookPos;

    HealthManager healthManager;

  private int currentWeaponIndex = 0;
  private int numberOfWeapons;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthManager = gameObject.GetComponent<HealthManager>();
    numberOfWeapons = GameObject.FindGameObjectWithTag("Weapon").transform.childCount;

      foreach (Transform child in GameObject.FindGameObjectWithTag("Weapon").transform)
      {
        if (child.gameObject.activeSelf == true)
        {
          LeftHandTarget = child.Find("Left Hand IK Target");
          RightHandTarget = child.Find("Right Hand IK Target");
          child.gameObject.GetComponent<IWeaponMechanic>().SetBoughtTheWeapon();
          break;
      }
            // if (child.tag != "RPG7")
            // {
            //     child.gameObject.SetActive(false);
                
            // }
            // else {
            //     LeftHandTarget = child.Find("Left Hand IK Target");
            //     RightHandTarget = child.Find("Right Hand IK Target");
            // }
      }

  }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.GetHealth() <= 0)
        {
          LeftHandWeight = 0;
          RightHandWeight = 0;
        }

    if (Input.GetKeyDown("q"))
    {
      Debug.Log("Get q down!!!!!!!!!!!!!!!!!!!!!!!!!");
      for (int i = 1; i < numberOfWeapons; i++)
      {
        int index = (currentWeaponIndex + i) % numberOfWeapons;
        if (GameObject.FindGameObjectWithTag("Weapon").transform.GetChild(index).GetComponent<IWeaponMechanic>().BoughtTheWeapon())
        {
          Debug.Log("Changing Weapon!!!!!!!!!!!!!!!!!!!!!!!!!: index " + index);
          GameObject.FindGameObjectWithTag("Weapon").transform.GetChild(currentWeaponIndex).transform.gameObject.SetActive(false);
          GameObject.FindGameObjectWithTag("Weapon").transform.GetChild(index).transform.gameObject.SetActive(true);
          GameObject.FindGameObjectWithTag("Weapon").transform.GetChild(index).GetComponent<IWeaponMechanic>().ReloadWeapon();
          LeftHandTarget = GameObject.FindGameObjectWithTag("Weapon").transform.GetChild(index).transform.Find("Left Hand IK Target");
          RightHandTarget = GameObject.FindGameObjectWithTag("Weapon").transform.GetChild(index).transform.Find("Right Hand IK Target");
          currentWeaponIndex = index;
          break;
        }
      }
    }
    }

    void OnAnimatorIK()
    {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftHandWeight);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandTarget.position);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, LeftHandWeight);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandTarget.rotation);

        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, RightHandWeight);
        animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandTarget.position);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, RightHandWeight);
        animator.SetIKRotation(AvatarIKGoal.RightHand, RightHandTarget.rotation);
    }

  public void EquipStoreItem(string itemName)
  {
    Debug.Log("The player has equiped item " + itemName + " !");
    Debug.Log("The first index of the weapon is: " + GameObject.FindGameObjectWithTag("Weapon").transform.GetChild(0).tag + "............................");
    Debug.Log("The childCount is: " + GameObject.FindGameObjectWithTag("Weapon").transform.childCount + "!!!!!!!!!!!!!!!!!!!!!!!!!!!");

    if (Equals(itemName, "Health Pack")){
      healthManager.ResetHealthToStarting();
    }
    else
    {
      foreach (Transform child in GameObject.FindGameObjectWithTag("Weapon").transform)
      {
        child.gameObject.SetActive(false);
        if (Equals(itemName, "Revolver") && child.tag == "Revolver")
        {
          Debug.Log("In Revolver");
          child.gameObject.SetActive(true);
          LeftHandTarget = child.Find("Left Hand IK Target");
          RightHandTarget = child.Find("Right Hand IK Target");
          child.gameObject.GetComponent<IWeaponMechanic>().ResupplyAmmo();
          child.gameObject.GetComponent<IWeaponMechanic>().SetBoughtTheWeapon();
          currentWeaponIndex = child.GetSiblingIndex();
        }
        else if (itemName == "RPG7" && child.tag == "RPG7")
        {
          child.gameObject.SetActive(true);
          LeftHandTarget = child.Find("Left Hand IK Target");
          RightHandTarget = child.Find("Right Hand IK Target");
          child.gameObject.GetComponent<IWeaponMechanic>().ResupplyAmmo();
          child.gameObject.GetComponent<IWeaponMechanic>().SetBoughtTheWeapon();
          currentWeaponIndex = child.GetSiblingIndex();
        }
        else if (itemName == "Rifle" && child.tag == "Rifle")
        {
          child.gameObject.SetActive(true);
          LeftHandTarget = child.Find("Left Hand IK Target");
          RightHandTarget = child.Find("Right Hand IK Target");
          child.gameObject.GetComponent<IWeaponMechanic>().ResupplyAmmo();
          child.gameObject.GetComponent<IWeaponMechanic>().SetBoughtTheWeapon();
          currentWeaponIndex = child.GetSiblingIndex();
        }
        else if (itemName == "Uzi" && child.tag == "Uzi")
        {
          child.gameObject.SetActive(true);
          LeftHandTarget = child.Find("Left Hand IK Target");
          RightHandTarget = child.Find("Right Hand IK Target");
          child.gameObject.GetComponent<IWeaponMechanic>().ResupplyAmmo();
          child.gameObject.GetComponent<IWeaponMechanic>().SetBoughtTheWeapon();
          currentWeaponIndex = child.GetSiblingIndex();
        }
        else if (itemName == "Shotgun" && child.tag == "Shotgun")
        {
          child.gameObject.SetActive(true);
          LeftHandTarget = child.Find("Left Hand IK Target");
          RightHandTarget = child.Find("Right Hand IK Target");
          child.gameObject.GetComponent<IWeaponMechanic>().ResupplyAmmo();
          child.gameObject.GetComponent<IWeaponMechanic>().SetBoughtTheWeapon();
          currentWeaponIndex = child.GetSiblingIndex();
        }
      }
    } 
  }
}

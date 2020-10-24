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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

      foreach (Transform child in GameObject.FindGameObjectWithTag("Weapon").transform)
      {
        if (child.gameObject.activeSelf == true)
        {
          LeftHandTarget = child.Find("Left Hand IK Target");
          RightHandTarget = child.Find("Right Hand IK Target");
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
    foreach (Transform child in GameObject.FindGameObjectWithTag("Weapon").transform)
    {
      child.gameObject.SetActive(false);
      if (Equals(itemName, "Revolver") && child.tag == "Revolver")
      {
        Debug.Log("In Revolver");
        child.gameObject.SetActive(true);
        LeftHandTarget = child.Find("Left Hand IK Target");
        RightHandTarget = child.Find("Right Hand IK Target");
      }
      else if (itemName == "RPG7" && child.tag == "RPG7")
      {
        child.gameObject.SetActive(true);
        LeftHandTarget = child.Find("Left Hand IK Target");
        RightHandTarget = child.Find("Right Hand IK Target");
      }
      else if (itemName == "Rifle" && child.tag == "Rifle")
      {
        child.gameObject.SetActive(true);
        LeftHandTarget = child.Find("Left Hand IK Target");
        RightHandTarget = child.Find("Right Hand IK Target");
      }
    }
  }
}

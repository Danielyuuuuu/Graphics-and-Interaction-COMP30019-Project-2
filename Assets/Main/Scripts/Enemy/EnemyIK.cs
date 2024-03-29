﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIK : MonoBehaviour
{
    Animator animator;

    public float LeftHandWeight = 1;
    public Transform LeftHandTarget;

    public float RightHandWeight = 1;
    public Transform RightHandTarget;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IWeaponMechanic
{

  void Start();

  void Update();

  void GunFire();

  void FindBarrel();

  float GetFireRate();

  Quaternion FiringDirection(float spreadRadius);

}



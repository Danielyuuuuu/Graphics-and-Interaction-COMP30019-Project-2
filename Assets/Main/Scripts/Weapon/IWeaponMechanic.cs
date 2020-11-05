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

  int GetBulletRamainingInTheMagazine();

  int GetBulletRamainingInTheBackupBullet();

  IEnumerator ReloadWeapon();

  string GetWeaponName();

  void ResupplyAmmo();

  bool BoughtTheWeapon();

  void SetBoughtTheWeapon();

  void SetReloadingToFalse();

  void CheckForReloadingAfterSwitchingWeapon();

  IEnumerator NoMoreBulletsMessage();

}



﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMechanic : MonoBehaviour, IWeaponMechanic
{

    AudioSource rifleAudio;
    public AudioClip gunSound;
    public AudioClip reloadSound;
    public Rigidbody projectilePrefab;
    public float fire_rate;
    public float bulletSpeed;

    Quaternion spreadAmount;
    Transform[] gunparts;
    Transform barrel;

  public int maxMagazineSize;
  private int bulletRamainingInTheMagazine;
  public int maxBackupBulletSize;
  private int bulletRamainingInTheBackupBullet;
  public int reloadTime;
  public bool isReloading = false;
  public GameObject reloadIcon;

  private bool boughtTheWeapon = false;

  private bool showNoMoreBullets = false;

  // Start is called before the first frame update
  public void Start()
    {
        FindBarrel();
        bulletRamainingInTheMagazine = maxMagazineSize;
        bulletRamainingInTheBackupBullet = maxBackupBulletSize;

        reloadIcon.SetActive(false);

        rifleAudio = GetComponent<AudioSource>();
  }

    // Update is called once per frame
    public void Update()
    {

    }

    public void GunFire()
    {
    if (bulletRamainingInTheMagazine > 0)
    {
      rifleAudio.PlayOneShot(gunSound);
      spreadAmount = FiringDirection(5);
      var p = Instantiate(projectilePrefab, barrel.position, barrel.rotation * spreadAmount);
      p.velocity = p.transform.forward * bulletSpeed;
      p.transform.Rotate(90f, barrel.rotation.y, barrel.rotation.z);

      bulletRamainingInTheMagazine -= 1;

      if (!isReloading && bulletRamainingInTheMagazine == 0 && bulletRamainingInTheBackupBullet > 0)
      {
        isReloading = true;
        Debug.Log("reload..............");
        rifleAudio.PlayOneShot(reloadSound);
        StartCoroutine(ReloadWeapon());
        Debug.Log("reload complete..............");
      }
      // explosion effect of the bullet
      // GameObject obj = Instantiate(this.createOnDestroy);
      // obj.transform.position = this.transform.position;
    }
    else
    {
      if (!isReloading && !showNoMoreBullets)
      {
        showNoMoreBullets = true;
        StartCoroutine(NoMoreBulletsMessage());
      }
      else if (!isReloading && bulletRamainingInTheBackupBullet > 0)
      {
        isReloading = true;
        Debug.Log("reload..............");
        rifleAudio.PlayOneShot(reloadSound);
        StartCoroutine(ReloadWeapon());
        Debug.Log("reload complete..............");
      }
    }
  }

    public void FindBarrel()
    {
        gunparts = this.GetComponentsInChildren<Transform>();
        foreach (Transform t in gunparts)
        {
            if (t.gameObject.name == "Gun Barrel")
            {
                barrel = t;
            }
        }
    }

    public Quaternion FiringDirection(float spreadRadius)
    {
        Quaternion candidate = Quaternion.Euler(0f, Random.Range(-spreadRadius, spreadRadius), 0f);
        return candidate.normalized;
    }

    public float GetFireRate()
    {
        return fire_rate;
    }

  public int GetBulletRamainingInTheMagazine()
  {
    return bulletRamainingInTheMagazine;
  }

  public int GetBulletRamainingInTheBackupBullet()
  {
    return bulletRamainingInTheBackupBullet;
  }

  public IEnumerator ReloadWeapon()
  {
    reloadIcon.SetActive(true);
    yield return new WaitForSeconds(reloadTime);

    if (maxMagazineSize <= bulletRamainingInTheBackupBullet)
    {
      bulletRamainingInTheMagazine = maxMagazineSize;
      bulletRamainingInTheBackupBullet -= maxMagazineSize;
    }
    else
    {
      bulletRamainingInTheMagazine = bulletRamainingInTheBackupBullet;
      bulletRamainingInTheBackupBullet = 0;
    }
    isReloading = false;
    reloadIcon.SetActive(false);
  }

  public string GetWeaponName()
  {
    return this.gameObject.tag;
  }

  public void ResupplyAmmo()
  {
    bulletRamainingInTheBackupBullet = maxBackupBulletSize;
    StartCoroutine(ReloadWeapon());
  }

  public bool BoughtTheWeapon()
  {
    return this.boughtTheWeapon;
  }

  public void SetBoughtTheWeapon()
  {
    this.boughtTheWeapon = true;
  }

  public void SetReloadingToFalse()
  {
    this.isReloading = false;
  }

  public void CheckForReloadingAfterSwitchingWeapon()
  {
    if (bulletRamainingInTheMagazine <= 0)
    {
      StartCoroutine(ReloadWeapon());
    }
  }

  public IEnumerator NoMoreBulletsMessage()
  {
    PopUpMessage.ShowPopUpMessage_Static("No more ammo! \nPurchase the same weapon again for ammo resupply");
    yield return new WaitForSeconds(1.5f);
    PopUpMessage.HidePopUpMessage_Static();
    showNoMoreBullets = false;
  }
}

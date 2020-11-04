﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGMechanic : MonoBehaviour, IWeaponMechanic
{
    AudioSource rpgAudio;
    public AudioClip gunSound;
    public AudioClip reloadSound;
    public Rigidbody projectilePrefab;
    public float fire_rate;
    public float bulletSpeed;

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

  // Start is called before the first frame update
  public void Start()
    {
        FindBarrel();
    bulletRamainingInTheMagazine = maxMagazineSize;
    bulletRamainingInTheBackupBullet = maxBackupBulletSize;

    reloadIcon.SetActive(false);
    rpgAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void GunFire()
    {
    if (bulletRamainingInTheMagazine > 0)
    {
      rpgAudio.PlayOneShot(gunSound);
      var p = Instantiate(projectilePrefab, barrel.position, barrel.rotation);
      p.transform.Rotate(barrel.rotation.x, -180.0f, barrel.rotation.z, Space.Self);
      //p.MoveRotation(p.rotation * )
      p.velocity = -p.transform.forward * bulletSpeed;

      bulletRamainingInTheMagazine -= 1;

      if (!isReloading && bulletRamainingInTheMagazine == 0)
      {
        isReloading = true;
        Debug.Log("reload..............");
        rpgAudio.PlayOneShot(reloadSound);
        StartCoroutine(ReloadWeapon());
        Debug.Log("reload complete..............");
      }
      // explosion effect of the bullet
      // GameObject obj = Instantiate(this.createOnDestroy);
      // obj.transform.position = this.transform.position;
    }
    else
    {
      if (!isReloading)
      {
        isReloading = true;
        Debug.Log("reload..............");
        rpgAudio.PlayOneShot(reloadSound);
        StartCoroutine(ReloadWeapon());
        Debug.Log("reload complete..............");
      }
    }
  }

    public Quaternion FiringDirection(float spreadRadius){
        // doesn't do anything
        return Quaternion.identity;
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

    public float GetFireRate()
    {
            Debug.Log("RPG_fire_rate");
            Debug.Log(fire_rate);
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
    if(bulletRamainingInTheMagazine <= 0)
    {
      StartCoroutine(ReloadWeapon());
    }
  }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunMechanic : MonoBehaviour, IWeaponMechanic
{
    public Rigidbody projectilePrefab;
    public float fire_rate;
    public int bulletPerShot;
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


  // Start is called before the first frame update
  public void Start()
    {
        FindBarrel();
    bulletRamainingInTheMagazine = maxMagazineSize;
    bulletRamainingInTheBackupBullet = maxBackupBulletSize;
  }

    // Update is called once per frame
    public void Update()
    {

    }

    public void GunFire()
    {
    if (bulletRamainingInTheMagazine > 0)
    {
      // Each shot produce 5 bullets in slightly random direction
      for (int i = 0; i < bulletPerShot; i++)
      {
        spreadAmount = FiringDirection(20);
        var p = Instantiate(projectilePrefab, barrel.position, barrel.rotation * spreadAmount);
        p.velocity = p.transform.forward * bulletSpeed;
        p.transform.Rotate(90f, barrel.rotation.y, barrel.rotation.z);
      }
      bulletRamainingInTheMagazine -= 1;
    }
    else
    {
      if (!isReloading)
      {
        isReloading = true;
        Debug.Log("reload..............");
        StartCoroutine(ReloadWeapon());
        Debug.Log("reload complete..............");
      }
    }

  }

    public Quaternion FiringDirection(float spreadRadius)
    {
        Quaternion candidate = Quaternion.Euler(0f, Random.Range(-spreadRadius, spreadRadius), 0f);
        return candidate.normalized;
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
  }
}

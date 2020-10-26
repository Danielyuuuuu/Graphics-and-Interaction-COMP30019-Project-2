using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMechanic : MonoBehaviour, IWeaponMechanic
{

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

  // Start is called before the first frame update
  public void Start()
    {
        FindBarrel();
    bulletRamainingInTheMagazine = maxMagazineSize;
    bulletRamainingInTheBackupBullet = maxBackupBulletSize;

    reloadIcon.SetActive(false);
  }

    // Update is called once per frame
    public void Update()
    {

    }

    public void GunFire()
    {
    if (bulletRamainingInTheMagazine > 0)
    {
      spreadAmount = FiringDirection(5);
      var p = Instantiate(projectilePrefab, barrel.position, barrel.rotation * spreadAmount);
      p.velocity = p.transform.forward * bulletSpeed;
      p.transform.Rotate(90f, barrel.rotation.y, barrel.rotation.z);

      bulletRamainingInTheMagazine -= 1;

      if (!isReloading && bulletRamainingInTheMagazine == 0)
      {
        isReloading = true;
        Debug.Log("reload..............");
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
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMechanic : MonoBehaviour, IWeaponMechanic
{

    public Rigidbody projectilePrefab;
    public float fire_rate;
    public float bulletSpeed;

    Transform[] gunparts;
    Transform barrel;


    // Start is called before the first frame update
    public void Start()
    {
        FindBarrel();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void GunFire()
    {
        var p = Instantiate(projectilePrefab, barrel.position, barrel.rotation);
        p.velocity = p.transform.forward * bulletSpeed;

        // explosion effect of the bullet
        // GameObject obj = Instantiate(this.createOnDestroy);
        // obj.transform.position = this.transform.position;
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
}

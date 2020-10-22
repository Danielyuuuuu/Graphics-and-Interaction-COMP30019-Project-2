﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    Transform[] childs;
    RifleMechanic weapon;

    float fire_rate;
    float rate_time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        FindCurrentWeapon();
        fire_rate = weapon.fire_rate;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time > rate_time)
        {
            rate_time = Time.time + fire_rate;
            weapon.GunFire();
        }
    }

    void FindCurrentWeapon()
    {
        childs = this.GetComponentsInChildren<Transform>();
        foreach (Transform t in childs)
        {
            if (t.gameObject.name == "Weapon")
            {
                weapon = t.GetComponentInChildren<RifleMechanic>();
            }
        }
    }

}

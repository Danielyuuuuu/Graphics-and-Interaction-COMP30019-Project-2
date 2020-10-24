using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    Transform[] childs;
    IWeaponMechanic weapon;

    float fire_rate;
    float rate_time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        FindCurrentWeapon();
        fire_rate = weapon.GetFireRate();
    }

    // Update is called once per frame
    void Update()
    {
        FindCurrentWeapon();
        fire_rate = weapon.GetFireRate();
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
                //weapon = t.GetComponentInChildren<IWeaponMechanic>();

              foreach (Transform child in t)
              {
                if (child.gameObject.activeSelf)
                {
                  weapon = t.GetComponentInChildren<IWeaponMechanic>();
                  break;
                }
              }



            }
        }
    }

}

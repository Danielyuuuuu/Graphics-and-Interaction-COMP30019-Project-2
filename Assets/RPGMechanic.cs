using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGMechanic : MonoBehaviour, IWeaponMechanic
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


        p.transform.Rotate(barrel.rotation.x, -180.0f, barrel.rotation.z, Space.Self);

        p.velocity = -p.transform.forward * bulletSpeed;

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
        Debug.Log("RPG_fire_rate");
        Debug.Log(fire_rate);
        return fire_rate;
  }
}


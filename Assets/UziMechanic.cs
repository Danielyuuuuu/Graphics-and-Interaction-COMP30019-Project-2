using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziMechanic : MonoBehaviour, IWeaponMechanic
{

    public Rigidbody projectilePrefab;
    public float fire_rate;
    public float bulletSpeed;

    Quaternion spreadAmount;
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
        spreadAmount = FiringDirection(15);
        var p = Instantiate(projectilePrefab, barrel.position, barrel.rotation*spreadAmount);
        p.velocity = p.transform.forward * bulletSpeed;
        p.transform.Rotate(90f, barrel.rotation.y, barrel.rotation.z);

        // explosion effect of the bullet
        // GameObject obj = Instantiate(this.createOnDestroy);
        // obj.transform.position = this.transform.position;
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
        Debug.Log("Uzi_fire_rate");
        Debug.Log(fire_rate);
        return fire_rate;
    }
}




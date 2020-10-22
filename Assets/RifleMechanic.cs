using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleMechanic : MonoBehaviour
{

    public Rigidbody projectilePrefab;
    public float fire_rate;

    Transform[] gunparts;
    Transform barrel;


    // Start is called before the first frame update
    void Start()
    {
        FindBarrel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GunFire()
    {
        var p = Instantiate(projectilePrefab, barrel.position, barrel.rotation);
        p.velocity = p.transform.forward * 10;

        // explosion effect of the bullet
        // GameObject obj = Instantiate(this.createOnDestroy);
        // obj.transform.position = this.transform.position;
    }

    void FindBarrel()
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectileController : MonoBehaviour
{
    public Vector3 velocity;

    public int damageAmount = 50;
    public string tagToDamage;
    public float bulletLifeTime;
    
    // Update is called once per frame
    
    void Update()
    {
        this.transform.Translate(velocity * Time.deltaTime);
        Destroy(this.gameObject, bulletLifeTime); 
    }
    

    
    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
      
        //Debug.Log("hiiiiiiiiiiiiiiiiiiiiiiii");
        if (col.gameObject.tag == tagToDamage)
        {
            // Damage object with relevant tag
            HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
            healthManager.ApplyDamage(damageAmount, this.gameObject.tag);

            // Destroy self
            Destroy(this.gameObject);

        }
    else if (col.gameObject.tag != "ShopTriggerArea" && col.gameObject.tag != "Untagged" && col.gameObject.tag != this.tag)
    {
      // Destroy self
      Destroy(this.gameObject);
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Vector3 velocity;

    public int damageAmount = 50;
    public string tagToDamage;


    public GameObject destroyExplosionPrefab_Rocket;

   
  // Update is called once per frame

  void Update()
     {
         this.transform.Translate(velocity * Time.deltaTime);
     }
    

    
    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
     

    Debug.Log("Collided with :" + col.gameObject.tag);
        if (col.gameObject.tag == tagToDamage)
        {

            // Damage object with relevant tag
            HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
        
            healthManager.ApplyDamage(damageAmount, this.gameObject.tag);

            // Destroy self
            Destroy(this.gameObject);
        }
    else if(col.gameObject.tag != "ShopTriggerArea" && col.gameObject.tag != null && col.gameObject.tag != this.tag && col.gameObject.tag != "Enemy")
    {
      if (this.tag == "Rocket")
      {
        GameObject explosion = Instantiate(this.destroyExplosionPrefab_Rocket);
        Debug.Log("EXPLOSION2");
        Debug.Log(this.destroyExplosionPrefab_Rocket);
        explosion.transform.position = this.transform.position;
      }
      // Destroy self
      Destroy(this.gameObject);
    }

        //else if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "Player") {
         //   Destroy(this.gameObject);
        //}

        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Vector3 velocity;

    public int damageAmount = 50;
    public string tagToDamage;
    

    // Update is called once per frame
    
     void Update()
     {
         this.transform.Translate(velocity * Time.deltaTime);
     }
    

    
    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == tagToDamage)
        {

            // Damage object with relevant tag
            HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
            Debug.Log("TAG!!!!!!!!!!!!!!!!!!!!!!!");    
            Debug.Log(this.gameObject.tag);

            healthManager.ApplyDamage(damageAmount, this.gameObject.tag);

            // Destroy self
            Destroy(this.gameObject);
        }

        //else if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "Player") {
         //   Destroy(this.gameObject);
        //}

        
    }
    
}

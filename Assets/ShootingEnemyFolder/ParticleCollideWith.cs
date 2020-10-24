using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollideWith : MonoBehaviour
{
    public string tagToDamage;
    public int damageAmount = 50;

    

    void OnParticleCollision(GameObject other) {
        
        if (other.tag == tagToDamage)
        {
            // Damage object with relevant tag
            HealthManager healthManager = other.GetComponent<HealthManager>();
            healthManager.ApplyDamage(damageAmount, this.gameObject.tag);

            // Destroy self
            //Destroy(this.gameObject);

           
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollideWith : MonoBehaviour
{
    public string tagToDamage;
    //public int damageAmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other) {
        
        if (other.tag == tagToDamage)
        {
            // Damage object with relevant tag
            //HealthManager healthManager = other.GetComponent<HealthManager>();
            //healthManager.ApplyDamage(damageAmount);

            Destroy(other);

            // Destroy self
            //Destroy(this.gameObject);

            Debug.Log("Particle collide with!!");
            Debug.Log(other.tag);
        }
    }
}

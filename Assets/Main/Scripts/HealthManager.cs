using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    public int startingHealth = 100;
    private int currentHealth;

    public GameObject bloodPrefab;
    public GameObject destroyExplosionPrefab;
    public GameObject destroyExplosionPrefab_Rocket;
    public Image damageScreen;

    public UnityEvent zeroHealthEvent;

    Animator animator;
    float alpha;

    void Start()
    { 
    if (this.tag == "Player")
    {
      if(GlobalOptions.difficulty < 1)
      {
        startingHealth = (int)(startingHealth * (1 + GlobalOptions.difficulty - 0.7));
      }
    }
    else
    {
      startingHealth = (int)(startingHealth * GlobalOptions.difficulty);
    }
    this.ResetHealthToStarting();
    animator = GetComponent<Animator>();
  }

    // Reset health to original starting health
    public void ResetHealthToStarting()
    {
        currentHealth = startingHealth;
    }

    // Reduce the health of the object by a certain amount
    // If health is zero, destroy the object
    public void ApplyDamage(int damage, string tag)
    {
        if (currentHealth > 0)
        {
            // Trigger Hit animation
            DetectHit();
            currentHealth -= damage;
            
            if (this.tag == "Player")
            {
                // Screen should flash red when player got hit
                StopCoroutine( FadeOut() );
                damageScreen.color = new Color(1f, 1f, 1f, 1f);
                StartCoroutine( FadeOut() );
            }

            if (this.tag == "Enemy")
            {
                GameObject blood = Instantiate(this.bloodPrefab);
                blood.transform.position = this.transform.position;
            }

            // this hit would kill the current game object
            if (currentHealth <= 0)
            {
                if (this.tag != "Player")
                {
                    if (tag == "Bullet")
                    {
                        GameObject explosion = Instantiate(this.destroyExplosionPrefab);
                        Debug.Log("EXPLOSION0");
                        Debug.Log(this.destroyExplosionPrefab.tag);
                        explosion.transform.position = this.transform.position;
                    }
                    else if (tag == "Rocket") {
                        GameObject explosion = Instantiate(this.destroyExplosionPrefab_Rocket);
                        Debug.Log("EXPLOSION1");
                        Debug.Log(this.destroyExplosionPrefab_Rocket.tag);
                        explosion.transform.position = this.transform.position;
                    }
                    

                    Destroy(this.gameObject);
                }
                else
                {
                    animator.SetTrigger("Die");
                    this.zeroHealthEvent.Invoke();

                    GameObject weapon = GameObject.FindGameObjectWithTag("Weapon");
                    weapon.SetActive(false);
                }
            }
        }
    }

    // Get the current health of the object
    public int GetHealth()
    {
        return this.currentHealth;
    }

    // Get the original health of the object
    public int GetOriginalHealth()
    {
        return this.startingHealth;
    }

    void DetectHit()
    {
        // Code for bullet detection ...

        // Reset the Hit animation to avoid it stacking up
        animator.ResetTrigger("Hit");
        animator.SetTrigger("Hit");
    }

    IEnumerator FadeOut()
    {
        float timePassed = 0f;
        // 1 is the fading duration (how long it takes to fade)
        while (timePassed < 0.5)
        {
            var lerpFactor = timePassed / 0.5;
            damageScreen.color = new Color (1f, 1f, 1f, Mathf.Lerp(1f, 0f, (float)lerpFactor));
            timePassed += Time.deltaTime;
            yield return null;
        }

        // make sure in the end the damage layer disappear
        damageScreen.color = new Color (1f, 1f, 1f, 0f);
    }


}

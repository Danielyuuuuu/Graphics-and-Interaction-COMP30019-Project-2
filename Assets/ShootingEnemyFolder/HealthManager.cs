using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int startingHealth = 100;
    private int currentHealth;

    public GameObject destroyExplosionPrefab;

    public UnityEvent zeroHealthEvent;

    Animator animator;
    PlayerMovementController controller;

  void Start()
    {
        this.ResetHealthToStarting();
        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerMovementController>();
    }

    // Reset health to original starting health
    public void ResetHealthToStarting()
    {
        currentHealth = startingHealth;
    }

    // Reduce the health of the object by a certain amount
    // If health is zero, destroy the object
    public void ApplyDamage(int damage)
    {
        if (currentHealth > 0)
      {
        // Trigger Hit animation
        DetectHit();
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            if (this.tag != "Player")
            {

                    GameObject explosion = Instantiate(this.destroyExplosionPrefab);
                    explosion.transform.position = this.transform.position;

                    Destroy(this.gameObject);
            }
            else
            {
              animator.SetTrigger("Die");
              controller.setPlayerDead();
              this.zeroHealthEvent.Invoke();
            }
      }
      }
    }

    // Get the current health of the object
    public int GetHealth()
    {
        return this.currentHealth;
    }

    void DetectHit()
    {
        // Code for bullet detection ...

        // Reset the Hit animation to avoid it stacking up
        animator.ResetTrigger("Hit");
        animator.SetTrigger("Hit");
    }
}

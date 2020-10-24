using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public ProjectileController projectilePrefab;
    public GameObject destroyExplosionPrefab;
    public float bulletSpeed;
    public float randomShooting;

    public float startAttackDistance = 10f;

    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    Animator animator;

  void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    public void DestroyMe()
    {
        GameObject explosion = Instantiate(this.destroyExplosionPrefab);
        explosion.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      float distance = Vector3.Distance(target.position, transform.position);
      if (distance <= lookRadius)
      {
        // Automatically handle nav agent rotation
        agent.SetDestination(target.position);
        float scaledDistance;
        if (distance <= 5.1)
        {
          scaledDistance = 0;
        } else 
        {
          scaledDistance = distance/8;
        }
        
        animator.SetFloat("Forward", scaledDistance);
        animator.SetFloat("Turn",0f);

        if (distance <= agent.stoppingDistance)
        {
          // Face the target
          FaceTarget();
        }
      }


        HealthManager healthManager = this.gameObject.GetComponent<HealthManager>();
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
        float difficulty = randomShooting;

        // Make enemy material darker based on its health
        renderer.material.color = Color.red * ((float)healthManager.GetHealth() / 100.0f);


        if (distance <= startAttackDistance)
        {
            if (UnityEngine.Random.value < (0.0005f + (0.004f * difficulty)))
            {
                //ProjectileController p = Instantiate<ProjectileController>(projectilePrefab);
                var p = Instantiate(projectilePrefab);


                //p.transform.position = this.transform.position;
                p.transform.position = new Vector3(this.transform.position.x, 1.3f, this.transform.position.z);

                p.transform.rotation = this.transform.rotation;

                //Vector3 relativePos = target.position - transform.position;

                //p.velocity = (target.position - this.transform.position).normalized * bulletSpeed;
                p.velocity = new Vector3(0f, 0f, 1f) * bulletSpeed;
                //p.velocity = this.transform.forward * bulletSpeed;

            }
        }
    }

  void FaceTarget()
  {
    Vector3 direction = (target.position - transform.position).normalized;
    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 8f);
  }
}

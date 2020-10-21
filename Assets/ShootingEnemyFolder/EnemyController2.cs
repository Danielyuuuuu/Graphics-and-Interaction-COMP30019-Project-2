using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public ProjectileController projectilePrefab;
    public GameObject destroyExplosionPrefab;
    public PlayerController2 player;
    public float bulletSpeed;
    public float randomShooting;

    public float startAttackDistance = 10f;

    Transform target;

    void Start()
    {
        target = PlayerManager.instance.player.transform;

        if (this.player == null)
        {
            Debug.Log(GameObject.FindGameObjectWithTag("Player"));
            this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2>();
        }
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
        HealthManager healthManager = this.gameObject.GetComponent<HealthManager>();
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
        float difficulty = randomShooting;

        // Make enemy material darker based on its health
        renderer.material.color = Color.red * ((float)healthManager.GetHealth() / 100.0f);

        float distance = Vector3.Distance(target.position, this.transform.position);

        if (distance <= startAttackDistance)
        {
            if (Random.value < (0.0005f + (0.004f * difficulty)))
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

 
}

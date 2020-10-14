using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public ProjectileController projectilePrefab;
    public GameObject destroyExplosionPrefab;
    public PlayerController2 player;

    void Start()
    {
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

        // Make enemy material darker based on its health
        renderer.material.color = Color.red * ((float)healthManager.GetHealth() / 100.0f);

        if (Random.value < (0.0005f + (0.004f * 0.5)))
        {
            ProjectileController p = Instantiate<ProjectileController>(projectilePrefab);
            //p.transform.position = new Vector3(this.transform.position.x, 1.3f, this.transform.position.z);
            p.transform.position = this.transform.position;
            Debug.Log(this.player);
            p.velocity = (this.player.transform.position - this.transform.position).normalized * 100.0f;
        }
    }
}

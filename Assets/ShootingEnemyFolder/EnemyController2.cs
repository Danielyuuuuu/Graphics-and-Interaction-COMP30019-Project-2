using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        HealthManager healthManager = this.gameObject.GetComponent<HealthManager>();
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

        // Make enemy material darker based on its health
        renderer.material.color = Color.red * ((float)healthManager.GetHealth() / 100.0f);
    }
}

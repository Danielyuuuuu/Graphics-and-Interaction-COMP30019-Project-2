using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBlur : MonoBehaviour
{
    public Shader rbShader;
    Material material;
    HealthManager player;

    float healthPercentage;
    float clearRadius;
    float maxRadius = 30f;
    float minRadius = 5f;

    void Start()
    {
        material = new Material(rbShader);
        player = PlayerManager.instance.player.GetComponent<HealthManager>();
    }

    void Update()
    {
        healthPercentage = (float) player.GetHealth() / player.GetOriginalHealth();

        // start adding blur when player health drops below 70%
        if (healthPercentage <= 0.7) {
            clearRadius = (maxRadius - minRadius) * healthPercentage + minRadius;
            material.SetFloat("_Radius", clearRadius);
            material.SetFloat("_EffectAmount", 1);
        } else {
            material.SetFloat("_EffectAmount", 0);
        }

    }

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src, dest, material);
    }
}

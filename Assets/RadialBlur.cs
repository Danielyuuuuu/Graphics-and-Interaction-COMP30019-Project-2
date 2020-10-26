using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBlur : MonoBehaviour
{
    public Shader rbShader;
    private Material material;

    void Start()
    {
        material = new Material(rbShader);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src, dest, material);
    }
}

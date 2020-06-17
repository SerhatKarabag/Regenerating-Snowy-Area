using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSC : MonoBehaviour
{
    public Shader _snowFallShader;
    [SerializeField] private Material _snowFallMaterial;
    [SerializeField] private MeshRenderer _meshRenderer;
    [Range(0.001f, 0.1f)]
    public float _FlakeAmount;
    [Range(0f, 1f)]
    public float _FlakeOpacity;
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _snowFallMaterial = new Material(_snowFallShader);
        _FlakeAmount = 0.015f;
        _FlakeOpacity = 0.08f;
    }

    // Update is called once per frame
    void Update()
    {
        _snowFallMaterial.SetFloat("_FlakeAmount", _FlakeAmount);
        _snowFallMaterial.SetFloat("_FlakeOpacity", _FlakeOpacity);
        RenderTexture snow = (RenderTexture)_meshRenderer.material.GetTexture("_Splat");
        RenderTexture temp = RenderTexture.GetTemporary(snow.width, snow.height, 0, RenderTextureFormat.ARGBFloat);
        Graphics.Blit(snow, temp, _snowFallMaterial);
        Graphics.Blit(temp , snow);
        _meshRenderer.material.SetTexture("_Splat", snow);
        RenderTexture.ReleaseTemporary(temp);
    }
}

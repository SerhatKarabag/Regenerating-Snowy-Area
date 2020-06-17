using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSC : MonoBehaviour
{
    [SerializeField] private RenderTexture _splatmap;
    [SerializeField] private Material _snowMaterial, _drawMaterial;
    [SerializeField] private RaycastHit _hit;
    [SerializeField] private static int _layerMask;
    [Range(2.5f, 37.5f)][SerializeField] private static float _size;
    public Shader _drawShader;
    public GameObject Terrain;
    public Transform SnowballTransform;
    void Start()
    {
        _layerMask = LayerMask.GetMask("Ground");
        _drawMaterial = new Material(_drawShader);
        _snowMaterial = Terrain.GetComponent<MeshRenderer>().material;
        _splatmap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
        _snowMaterial.SetTexture("_Splat", _splatmap);
        _size = 2.5f;
    }
    void Update()
    {
        if (Physics.Raycast(SnowballTransform.position, -Vector3.up, out _hit, 1f, _layerMask))
        {
            _drawMaterial.SetVector("_Coordinate", new Vector4(_hit.textureCoord.x, _hit.textureCoord.y, 0, 0));
            _drawMaterial.SetFloat("_Size", _size);
            RenderTexture temp = RenderTexture.GetTemporary(_splatmap.width, _splatmap.height, 0, RenderTextureFormat.ARGBFloat);
            Graphics.Blit(_splatmap, temp);
            Graphics.Blit(temp, _splatmap, _drawMaterial);
            RenderTexture.ReleaseTemporary(temp);
            Renderer renderer = _hit.collider.GetComponent<MeshRenderer>();
        }
    }
}




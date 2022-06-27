using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDirt : MonoBehaviour
{
    private Material material;
    private Texture texture;
    public bool cleaned = false;
    void Start()
    {
        var renderer = GetComponent<MeshRenderer>();
        material = Instantiate(renderer.sharedMaterial);
        renderer.material = material;
        texture = material.GetTexture("_CleanText");
        material.SetInt("_Cleaned", 0);
        cleaned = false;
    }

    private void OnDestroy()
    {
        if (material != null)
        {
            Destroy(material);
        }
    }

    public void CleanDirt(Vector3 center)
    {
        cleaned = true;
        material.SetInt("_Cleaned", 1);
        material.SetVector("_waveCenter", center);
        material.SetFloat("_waveStartTime", Time.time);
    }
}

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LightingController : MonoBehaviour
{

    public Color color;

    void Start()
    {
        UpdateLighting();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            UpdateLighting();
        }
    }

    private void UpdateLighting()
    {
        RenderSettings.ambientSkyColor = color;
    }
}
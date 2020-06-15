using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class WaterManager : MonoBehaviour
{
    private MeshFilter filter;

    private void Awake()
    {
        filter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        // gets all vertices and sets them correctly according to the wave height
        Vector3[] vertices = filter.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + vertices[i].x);
        }

        filter.mesh.vertices = vertices;
        filter.mesh.RecalculateNormals();
    }
}

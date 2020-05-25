﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{

    // NIET IN GEBRUIK!

    [SerializeField]
    private int dimensions = 10;
    public Octave[] octaves;
    [SerializeField]
    private float uvScale;

    protected MeshFilter meshFilter;
    protected Mesh mesh;
    
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        mesh.name = gameObject.name;

        mesh.vertices = GenerateVerts();
        mesh.triangles = GenerateTries();
        mesh.uv = GenerateUVs();
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }

    public float GetHeight(Vector3 position)
    {
        var scale = new Vector3(1 / transform.lossyScale.x, 0, 1 / transform.lossyScale.z);
        var localPos = Vector3.Scale((position - transform.position), scale);

        var p1 = new Vector3(Mathf.Floor(localPos.x), 0, Mathf.Floor(localPos.z));
        var p2 = new Vector3(Mathf.Floor(localPos.x), 0, Mathf.Ceil(localPos.z));
        var p3 = new Vector3(Mathf.Ceil(localPos.x), 0, Mathf.Floor(localPos.z));
        var p4 = new Vector3(Mathf.Ceil(localPos.x), 0, Mathf.Ceil(localPos.z));

        p1.x = Mathf.Clamp(p1.x, 0, dimensions);
        p1.z = Mathf.Clamp(p1.z, 0, dimensions);
        p2.x = Mathf.Clamp(p2.x, 0, dimensions);
        p2.z = Mathf.Clamp(p2.z, 0, dimensions);
        p3.x = Mathf.Clamp(p3.x, 0, dimensions);
        p3.z = Mathf.Clamp(p3.z, 0, dimensions);
        p4.x = Mathf.Clamp(p4.x, 0, dimensions);
        p4.z = Mathf.Clamp(p4.z, 0, dimensions);

        float max = Mathf.Max(Vector3.Distance(p1, localPos), Vector3.Distance(p2, localPos), Vector3.Distance(p3, localPos), Vector3.Distance(p4, localPos) + Mathf.Epsilon);
        float dist = (max - Vector3.Distance(p1, localPos)) 
                     + (max - Vector3.Distance(p2, localPos)) 
                     + (max - Vector3.Distance(p3, localPos)) 
                     + (max = Vector3.Distance(p4, localPos));

        float height = mesh.vertices[index(p1.x, p1.z)].y * (max - Vector3.Distance(p1, localPos)) 
                     + mesh.vertices[index(p2.x, p2.z)].y * (max - Vector3.Distance(p2, localPos)) 
                     + mesh.vertices[index(p3.x, p3.z)].y * (max - Vector3.Distance(p3, localPos)) 
                     + mesh.vertices[index(p4.x, p4.z)].y * (max - Vector3.Distance(p4, localPos));

        return height * transform.lossyScale.y / dist;
    }

    private int[] GenerateTries()
    {
        var tries = new int[mesh.vertices.Length * 6];

        for(int x = 0; x < dimensions; x++)
        {
            for (int z = 0; z < dimensions; z++)
            {
                tries[index(x, z) * 6 + 0] = index(x, z);
                tries[index(x, z) * 6 + 1] = index(x + 1, z + 1);
                tries[index(x, z) * 6 + 2] = index(x + 1, z);
                tries[index(x, z) * 6 + 3] = index(x, z);
                tries[index(x, z) * 6 + 4] = index(x, z + 1);
                tries[index(x, z) * 6 + 5] = index(x + 1, z + 1);
            }
        }
        return tries;
    }

    private Vector2[] GenerateUVs()
    {
        var uvs = new Vector2[mesh.vertices.Length];

        for (int x = 0; x <= dimensions; x++)
        {
            for (int z = 0; z <= dimensions; z++)
            {
                var vec = new Vector2((x / uvScale) % 2, (z / uvScale) % 2);
                uvs[index(x, z)] = new Vector2(vec.x <= 1 ? vec.x : 2 - vec.x, vec.y <= 1 ? vec.y : 2 - vec.y);
            }
        }

        return uvs;
    }

    private Vector3[] GenerateVerts()
    {
        var verts = new Vector3[(dimensions + 1) * (dimensions + 1)];

        for (int x = 0; x <= dimensions; x++)
        
            for (int z = 0; z <= dimensions; z++)
            
                verts[index(x, z)] = new Vector3(x, 0, z);
            
        
        return verts;
        
    }

    private int index(float x, float z)
    {
        return (int)( x * (dimensions + 1) + z);
    }

    // Update is called once per frame
    void Update()
    {
        var verts = mesh.vertices;
        for (int x = 0; x <= dimensions; x++)
        {
            for (int z = 0; z <= dimensions; z++)
            {
                float y = 0f;
                for (int o = 0; o < octaves.Length; o++)
                {
                    if (octaves[o].alternate)
                    {
                        float perl = Mathf.PerlinNoise((x * octaves[o].scale.x) / dimensions, (z * octaves[o].scale.y) / dimensions) * Mathf.PI * 2f;
                        y += Mathf.Cos(perl + octaves[o].speed.magnitude * Time.time) * octaves[o].height;
                    }
                    else
                    {
                        float perl = Mathf.PerlinNoise((x * octaves[o].scale.x + Time.time * octaves[o].speed.x) / dimensions, (z * octaves[o].scale.y + Time.time * octaves[o].speed.y) / dimensions) - 0.5f;
                        y += perl * octaves[o].height;
                    }
                }
                verts[index(x, z)] = new Vector3(x, y, z);
            }
        }
        mesh.vertices = verts;
        mesh.RecalculateNormals();
    }

    [Serializable]
    public struct Octave
    {
        public Vector2 speed;
        public Vector2 scale;
        public float height;
        public bool alternate;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField]
    private int dimensions = 10;
    public Octave[] octaves;

    protected MeshFilter meshFilter;
    protected Mesh mesh;
    
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        mesh.name = gameObject.name;

        mesh.vertices = GenerateVerts();
        mesh.triangles = GenerateTries();
        mesh.RecalculateBounds();

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
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

    private Vector3[] GenerateVerts()
    {
        var verts = new Vector3[(dimensions + 1) * (dimensions + 1)];

        for (int x = 0; x <= dimensions; x++)
        
            for (int z = 0; z <= dimensions; z++)
            
                verts[index(x, z)] = new Vector3(x, 0, z);
            
        
        return verts;
        
    }

    private int index(int x, int z)
    {
        return x * (dimensions + 1) + z;
    }

    // Update is called once per frame
    void Update()
    {
        var verts = mesh.vertices;
        for (int x = 0; x <= dimensions; x++)
        {
            for (int z = 0; z <= dimensions; z++)
            {
                var y = 0f;
                for (int o = 0; o < octaves.Length; o++)
                {
                    if (octaves[o].alternate)
                    {
                        var perl = Mathf.PerlinNoise((x * octaves[o].scale.x) / dimensions, (z * octaves[o].scale.y) / dimensions) * Mathf.PI * 2f;
                        y += Mathf.Cos(octaves[o].speed.magnitude * Time.time) * octaves[o].height;
                    }
                }
                verts[index(x, z)] = new Vector3(x, y, z);
            }
        }
        mesh.vertices = verts;
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

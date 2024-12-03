using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCurve : MonoBehaviour
{
    // Start is called before the first frame update
    private Mesh mesh;
    private Vector3[] originalVertices;
    
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        originalVertices = mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = new Vector3[originalVertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = originalVertices[i];
            vertex.y = Mathf.Sin(vertex.x * Mathf.PI + Time.time); // Adjust Y-axis for curve
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}

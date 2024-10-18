using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode()]
public class SplineAddPointsAlongMesh : MonoBehaviour
{
    [SerializeField] private SplineSampler splineSampler;
    [SerializeField] private float resolution = 10f; // Number of points to sample the spline
    [SerializeField] private int subdivisionX = 4;
    [SerializeField] private int subdivisionY = 3;

    public List<Vector3> vertsP1;
    public List<Vector3> vertsP2;
    private Vector3 vertsEndP1;
    private Vector3 vertsEndP2;
    private MeshFilter meshFilter;

    private void Start()
    {
        // Ensure a MeshFilter and MeshRenderer are attached
        meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            meshFilter = gameObject.AddComponent<MeshFilter>();
        }

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
        }
    }

    private void Update()
    {
        if (splineSampler == null) return;

        GetVerts();
        BuildMesh();
    }

    private void GetVerts()
    {
        vertsP1 = new List<Vector3>();
        vertsP2 = new List<Vector3>();

        vertsEndP1 = new Vector3();
        vertsEndP2 = new Vector3();

        float step = 1f / resolution;

        for (int i = 0; i <= resolution; i++) // Include endpoint
        {
            float t = step * i;
            splineSampler.SampleSpline(t, out Vector3 p1, out Vector3 p2);

            // Convert spline points to local space relative to the GameObject
            vertsP1.Add(transform.InverseTransformPoint(p1));
            vertsP2.Add(transform.InverseTransformPoint(p2));

            splineSampler.SampleSpline(0f, out Vector3 startLeft, out Vector3 startRight);


            /*vertsEndP1 = (transform.InverseTransformPoint(endLeft));
            vertsEndP2 = (transform.InverseTransformPoint(endRight));*/
        }
    }

    private void BuildMesh()
    {
        if (vertsP1.Count < 2 || vertsP2.Count < 2) return;

        splineSampler.SampleSpline(1f, out Vector3 endLeft, out Vector3 endRight);
        vertsP1.Add(transform.InverseTransformPoint(endLeft));
        vertsP2.Add(transform.InverseTransformPoint(endRight));

        Mesh mesh = new Mesh();
        List<Vector3> verts = new List<Vector3>();
        List<int> tris = new List<int>();
        List<Vector2> uvs = new List<Vector2>(); // Optional for texture mapping

        // Loop through vertsP1 and vertsP2 to create quads
        for (int i = 0; i < vertsP1.Count - 1; i++)
        {
            Vector3 p1 = vertsP1[i];
            Vector3 p2 = vertsP2[i];
            Vector3 p3 = vertsP1[i + 1];
            Vector3 p4 = vertsP2[i + 1];

            // Subdivide each quad based on subdivisionX and subdivisionY
            for (int x = 0; x < subdivisionX; x++)
            {
                for (int y = 0; y < subdivisionY; y++)
                {
                    // Calculate the positions of the corners of the smaller quad
                    float u = x / (float)subdivisionX;
                    float v = y / (float)subdivisionY;

                    Vector3 newP1 = Vector3.Lerp(Vector3.Lerp(p1, p2, u), Vector3.Lerp(p3, p4, u), v);
                    Vector3 newP2 = Vector3.Lerp(Vector3.Lerp(p1, p2, u + 1f / subdivisionX), Vector3.Lerp(p3, p4, u + 1f / subdivisionX), v);
                    Vector3 newP3 = Vector3.Lerp(Vector3.Lerp(p1, p2, u), Vector3.Lerp(p3, p4, u), v + 1f / subdivisionY);
                    Vector3 newP4 = Vector3.Lerp(Vector3.Lerp(p1, p2, u + 1f / subdivisionX), Vector3.Lerp(p3, p4, u + 1f / subdivisionX), v + 1f / subdivisionY);

                    // Add vertices for the smaller quad
                    verts.AddRange(new List<Vector3> { newP1, newP2, newP4, newP3 });

                    // Add two triangles for the smaller quad, with inverted winding order
                    int baseIndex = verts.Count - 4; // Current base index for the new quad
                    tris.AddRange(new List<int>
                {
                    baseIndex + 2, baseIndex + 1, baseIndex, // First triangle (newP4, newP2, newP1)
                    baseIndex + 3, baseIndex + 2, baseIndex   // Second triangle (newP3, newP4, newP1)
                });

                    // Optional: Add UVs for texture mapping
                    uvs.AddRange(new List<Vector2>
                {
                    new Vector2(u, v),
                    new Vector2(u + 1f / subdivisionX, v),
                    new Vector2(u + 1f / subdivisionX, v + 1f / subdivisionY),
                    new Vector2(u, v + 1f / subdivisionY)
                });
                }
            }
        }

        // Assign the vertices and triangles to the mesh
        mesh.SetVertices(verts);
        mesh.SetTriangles(tris, 0);
        mesh.SetUVs(0, uvs); // Optional, if UVs are needed for texturing
        mesh.RecalculateNormals(); // Optional; use if needed

        // Apply the mesh to the MeshFilter
        meshFilter.mesh = mesh;
    }


    /*private void OnDrawGizmos()
    {
        // Ensure that splineSampler is not null and contains valid data
        if (splineSampler == null || vertsP1 == null || vertsP2 == null) return;

        Handles.color = Color.red;

        // Draw Gizmos for each point
        for (int i = 0; i < vertsP1.Count; i++)
        {
            // Get the world position by transforming the local vertices back to world space
            Vector3 worldP1 = transform.TransformPoint(vertsP1[i]);
            Vector3 worldP2 = transform.TransformPoint(vertsP2[i]);

            // Draw spheres at p1 and p2
            Gizmos.DrawSphere(worldP1, 0.1f); // Use a smaller radius for points
            Gizmos.DrawSphere(worldP2, 0.1f);

            // Optionally, draw a line between p1 and p2 to visualize the width
            Gizmos.color = Color.green;
            Gizmos.DrawLine(worldP1, worldP2);
        }
        Vector3 worldEndP1 = transform.TransformPoint(vertsEndP1);
        Vector3 worldEndP2 = transform.TransformPoint(vertsEndP2);
        Gizmos.DrawSphere(worldEndP1, 0.1f); // Use a smaller radius for points
        Gizmos.DrawSphere(worldEndP2, 0.1f);
        Gizmos.DrawLine(worldEndP1, worldEndP2);
    }*/

}
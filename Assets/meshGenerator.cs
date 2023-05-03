using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class meshGenerator : MonoBehaviour
{
    Mesh mesh; // creating a mesh object and storing it in mesh of type Mesh
    Vector3[] vertices; // array of vertices of type vector3
    int[] triangles; // array of tringles
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh(); // actual creation of the new mesh object in the start of the game butoon press
        GetComponent<MeshFilter>().mesh=mesh; // adding the mesh created to our mesh filter
        craeteShape();
        UpdateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void craeteShape()
    {
        vertices=new Vector3[]
        {
            new Vector3 (0,0,0),
            new Vector3 (0,0,1),
            new Vector3 (1,0,0),
            new Vector3 (1,0,1)
        };

        triangles = new int[]
        {
            0,1,2,
            1,3,2
        };
    }

    void UpdateMesh()
    {
        mesh.Clear(); // just important as well to clear up things before drawing new meshes
        mesh.vertices=vertices;
        mesh.triangles=triangles;
        mesh.RecalculateNormals(); // just important code of line in unity
    }
}

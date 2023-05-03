using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class gridGenerator : MonoBehaviour
{
    Mesh mesh; // creating a mesh object and storing it in mesh of type Mesh
    Vector3[] vertices; // array of vertices of type vector3
    int[] triangles; // array of tringles
    public int xSize=20;
    public int zSize=20;
        // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh(); // actual creation of the new mesh object in the start of the game butoon press
        GetComponent<MeshFilter>().mesh=mesh; // adding the mesh created to our mesh filter
        StartCoroutine(craeteShape());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMesh();
    }

    IEnumerator craeteShape()
    {
        vertices = new Vector3[(xSize+1) * (zSize+1)];
        for (int i=0, z=0; z<=zSize; z++)
        {
            for(int x=0; x<=xSize; x++)
            {
                float y=Mathf.PerlinNoise(x*.3f, z*.3f)*2f;
                vertices[i]=new Vector3(x,y,z);
                i++;
            }
        }
        triangles=new int[xSize*zSize*6];

        int vert=0;
        int tris=0;
        for (int z=0; z<zSize; z++)
        {
            for(int x=0; x<xSize; x++)
            {
                triangles[tris+0]= vert + 0;
                triangles[tris+1]= vert + xSize+1;
                triangles[tris+2]= vert + 1;
                triangles[tris+3]= vert + 1;
                triangles[tris+4]= vert +xSize+1;
                triangles[tris+5]= vert + xSize+2;

                vert++;
                tris+=6;
                yield return new WaitForSeconds(.1f);
            }
            vert++;
        }
        
       
    }

    void UpdateMesh()
    {
        mesh.Clear(); // just important as well to clear up things before drawing new meshes
        mesh.vertices=vertices;
        mesh.triangles=triangles;
        mesh.RecalculateNormals(); // just important code of line in unity
    }

     /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    private void OnDrawGizmos()
    {
        if(vertices==null)
        return;

        for(int i=0; i<vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
        
    }
}

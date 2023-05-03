using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainPerlin : MonoBehaviour
{
  public int depth=20;
  public int width=256;
  public int height=256;
  public float scale=20f;
  public float offsetX=100f;
  public float offsetY=100f;

  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  private void Start()
  {
    offsetX=Random.Range(0f,9999f);
    offsetY=Random.Range(0f, 9999f);
  }

 /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  private void Update()
  {
    Terrain terrain=GetComponent<Terrain>();
    terrain.terrainData=GenerateTerrain(terrain.terrainData);
    offsetX+=Time.deltaTime*5;
    offsetY+=Time.deltaTime*5;
  }

  TerrainData GenerateTerrain(TerrainData terrainData)
  {
    terrainData.heightmapResolution=width+1;
    terrainData.size=new Vector3(width, depth, height);
    terrainData.SetHeights(0,0, GenerateHeights());
    return terrainData;
  }
  float[,]GenerateHeights ()
  {
    float[,]heights=new float[width, height];
    for(int x=0; x<width; x++)
    {
        for(int y=0; y<height; y++)
        {
            heights[x,y]=CalculateHeight(x,y);
        }
    }
    return heights;
  }
  float CalculateHeight(int x, int y)
  {
    float xCoord=(float)x/width*scale+offsetX;
    float yCoord=(float)y/height*scale+offsetY;
    return Mathf.PerlinNoise(xCoord, yCoord);
  }
}

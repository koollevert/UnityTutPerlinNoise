using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
   public int width=256;
   public int height=256;
   public float scale=20f;
   public float offsetX=100f;
   public float offsetY=100f;

   /// <summary>
   /// Start is called on the frame when a script is enabled just before
   /// any of the Update methods is called the first time.
   /// </summary>
   private void Start() // everytime play is pressed on unity its going to be different
   {
      offsetX=Random.Range(0f, 99999f);
      offsetY=Random.Range(offsetX, 99999f);
   }
   /// <summary>
   /// Start is called on the frame when a script is enabled just before
   /// any of the Update methods is called the first time.
   /// </summary>
   private void Update() // changed form start to update function
   {
      Renderer renderer =GetComponent<Renderer>();
      renderer.material.mainTexture=GenerateTexture();
   }
   Texture2D GenerateTexture()
   {
      Texture2D texture=new Texture2D(width, height);
      //GENERATE A PERLIN NOISE MAP FOR THE TEXTURE
      for (int x=0; x<width; x++)
      {
         for(int y=0; y<height; y++)
         {
            Color color=CalculateColor(x,y);
            texture.SetPixel(x,y, color);
         }
      }
      texture.Apply();
      return texture;
   }

   Color CalculateColor(int x, int y)
   {
      float XCoord= (float)x/width*scale+offsetX;
      float yCoord= (float)y/height*scale+offsetY;
      float sample=Mathf.PerlinNoise(XCoord,yCoord);
      return new Color(sample, sample, sample);
   }
  
}

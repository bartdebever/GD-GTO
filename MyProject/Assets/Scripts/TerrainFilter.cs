using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFilter : MonoBehaviour
{
    public Material GroundMaterial;
    public Material GrassMaterial;
    public Material WallMaterial;

    public void TextureTerain(GridContainer Grid)
    {
        foreach (var tile in Grid.GetTiles())
        {
            var random = Random.Range(0, 100);
            if(random < 75)
                tile.gameObject.GetComponent<Renderer>().material = GrassMaterial;
            else
                tile.gameObject.GetComponent<Renderer>().material = GroundMaterial;
        }

        foreach (var wall in Grid.GetWalls())
        {
            wall.gameObject.GetComponent<Renderer>().material = WallMaterial;
        }
    }
}

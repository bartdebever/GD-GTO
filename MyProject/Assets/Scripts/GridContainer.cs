using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridContainer : MonoBehaviour
{
    private List<TileScript> Tiles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitList()
    {
        this.Tiles = new List<TileScript>();
    }
    public void AddTile(TileScript tile)
    {
        if(Tiles == null)
            this.InitList();
        Tiles.Add(tile);
    }

    public void AddTiles(IEnumerable<TileScript> tiles)
    {
        if(Tiles == null)
            this.InitList();
        Tiles.AddRange(tiles);
    }

    public List<TileScript> GetTiles()
    {
        return Tiles;
    }

    public bool MoveTo(float x, float z)
    {
        var tile = Tiles.FirstOrDefault(obj =>
            obj.transform.position.x.Equals(x) && obj.transform.position.z.Equals(z));
        if (tile != null)
        {
            var resource = tile.GetComponentInChildren<Resource>();
            if (resource != null)
            {
                Destroy(resource.gameObject);
                //Add resource to player
            }

            return true;
        }

        return false;

    }
}

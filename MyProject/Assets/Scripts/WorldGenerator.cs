using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject Tile;
    public GameObject Pickup;

    public GridContainer Grid;

    public int XMax;
    public int ZMax;
    public int YMax;
    public int PickupAmount;

    public bool GenerateHills;
	// Use this for initialization
	void Start ()
	{
	    Generate();
	}

    void Generate()
    {
        for (int x = 0; x < XMax; x++)
        {
            for (int z = 0; z < ZMax; z++)
            {
                var gameObjectTile = Tile.GetComponent<TileScript>().Initialize(x, z, 0, transform);
                this.Grid.AddTile(gameObjectTile.GetComponent<TileScript>());
            }
        }
        for(int i = 0; i < PickupAmount; i++)
        {
            var tiles = Grid.GetTiles();
            var tile = tiles[Random.Range(0, tiles.Count)];
            if (tile != null)
            {
                tile.SpawnPickup(Pickup);
            }
        }
    }
}

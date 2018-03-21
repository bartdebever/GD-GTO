﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject Tile;
    public GameObject Pickup;
    [Header("Grid Container")]
    public GridContainer Grid;
    [Header("Generation Size")]
    public int XMax;
    public int ZMax;
    public int XMin;
    public int ZMin;
    public int YMax;
    [Header("Generation Modifiers")]
    public int PickupAmount;
    public bool GenerateHills;
	// Use this for initialization
	void Start ()
	{
	    Generate();
	}

    void Generate()
    {
        for (int x = XMin; x < XMax; x++)
        {
            for (int z = ZMin; z < ZMax; z++)
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

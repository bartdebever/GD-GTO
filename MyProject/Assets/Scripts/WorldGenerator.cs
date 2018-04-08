using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject Tile;
    public GameObject Pickup;
    public List<GameObject> Enemy;
    [Header("Containers and Controllers")]
    public GridContainer Grid;
    public TerrainFilter TerrainFilter;
    public ShopScript Shop;
    public EnemyController EnemyController;
    [Header("Generation Size")]
    public int XMax;
    public int ZMax;
    public int XMin;
    public int ZMin;
    public int YMax;
    [Header("Generation Modifiers")]
    public int PickupAmount;
    public bool GenerateHills;
    public int Enemies;
    [Header("Cameras")] public Camera PauseCamera;
    // Use this for initialization
    void Start ()
	{
	    Generate();
	    int ShopX = XMax;
	    if (XMin < 0)
	        ShopX += -XMin;
	    else
	        ShopX += XMin;
	    int shopZ = ZMax;
	    if (ZMin < 0)
	        ShopX += -ZMin;
	    else
	        ShopX += ZMin;
        Shop.Spawn(new Vector3(0 - Shop.XSize/2f, 0, shopZ));
        TerrainFilter.TextureTerain(Grid);
        PauseCamera.transform.position = new Vector3(0, 20, 0);
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
        GeneratePickup();
        GenerateEnemies();
        GenerateWalls();
    }

    private void GeneratePickup()
    {
        var tiles = Grid.GetTiles();
        for (int i = 0; i < PickupAmount; i++)
        {
            var tile = tiles[Random.Range(0, tiles.Count)];
            if (tile != null)
            {
                tile.SpawnPickup(Pickup);
            }
        }
    }
    private void GenerateEnemies()
    {
        var tiles = Grid.GetTiles();
        foreach (var enemyScript in Enemy)
        {
            for (int i = 0; i < Enemies; i++)
            {
                var tile = tiles[Random.Range(0, tiles.Count)];
                if (tile != null && tile.gameObject.transform.position.x > XMin + 2 && tile.gameObject.transform.position.x < XMax - 2
                    && tile.gameObject.transform.position.z > ZMin + 2 && tile.gameObject.transform.position.x < XMax - 2)
                {
                    var position = tile.transform.position;
                    var enemy = enemyScript.GetComponent<EnemyScript>().Initialize(position.x, position.z, position.y + 1.5f, tile.transform);
                    EnemyController.AddEnemy(enemy.GetComponent<EnemyScript>());
                }
            }
        }
    }
    private void GenerateWalls()
    {
        for (int h = 0; h < 2; h++)
        {
            for (int x = XMin; x < XMax; x++)
            {
                for (int i = 0; i<2; i++)
                {
                    if (i == 0)
                    {
                        var wall = Tile.GetComponent<TileScript>().Initialize(x, ZMin-1, h, transform);
                        wall.GetComponent<Renderer>().material.color = Color.gray;
                        Grid.AddWall(wall.GetComponent<TileScript>());
                    }
                    else
                    {
                        var wall = Tile.GetComponent<TileScript>().Initialize(x, ZMax, h, transform);
                        wall.GetComponent<Renderer>().material.color = Color.grey;
                        Grid.AddWall(wall.GetComponent<TileScript>());
                    }
                        

                }
            }

            for (int z = ZMin; z < ZMax; z++)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        var wall = Tile.GetComponent<TileScript>().Initialize(XMin-1, z, h, transform);
                        wall.GetComponent<Renderer>().material.color = Color.gray;
                        Grid.AddWall(wall.GetComponent<TileScript>());
                    }
                    else
                    {
                        var wall = Tile.GetComponent<TileScript>().Initialize(XMax, z, h, transform);
                        wall.GetComponent<Renderer>().material.color = Color.grey;
                        Grid.AddWall(wall.GetComponent<TileScript>());
                    }


                }
            }
        }

    }
}

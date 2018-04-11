using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridContainer : MonoBehaviour
{
    private List<TileScript> Tiles;

    private List<TileScript> Walls;
	// Use this for initialization
	void Start () {
		Debug.Log(Game.GetNumberOfPlayers());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitList()
    {
        this.Tiles = new List<TileScript>();
    }

    public List<TileScript> GetWalls()
    {
        return Walls;
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

    public void AddWall(TileScript wall)
    {
        if(this.Walls == null)
            this.Walls = new List<TileScript>();
        this.Walls.Add(wall);
    }

    public void RemoveTile(Vector3 position)
    {
        var tile = Tiles.FirstOrDefault(x => x.gameObject.transform.position.Equals(position));
        if (tile != null)
        {
            Tiles.Remove(tile);
            Destroy(tile.gameObject);
        }
        var wall = Walls.FirstOrDefault(x => x.gameObject.transform.position.Equals(position));
        if (wall != null)
        {
            Walls.Remove(wall);
            Destroy(wall.gameObject);
        }
    }

    public List<TileScript> GetTiles()
    {
        return Tiles;
    }
    public bool MoveTo(float x, float z, PlayerScript player)
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

            var enemy = tile.GetComponentInChildren<EnemyScript>();
            if (enemy != null)
            {
                enemy.GetHit(player.Attack);
                if (enemy.Health > 0)
                    return false;
                Destroy(enemy.gameObject);
            }

            return true;
        }

        return false;
    }
}

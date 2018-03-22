using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShopScript : MonoBehaviour
    {
        public GameObject Block;
        public List<ItemScript> Items;
        public GameObject Pickup; //TEMPORARY
        public GridContainer Grid;
        private List<TileScript> tiles = new List<TileScript>();
        public int XSize;
        public int ZSize;
        public int YSize;
        public void Spawn(Vector3 position)
        { 
            for (int x = 1; x < XSize; x++)
            {
                for (int z = 1; z < ZSize; z++)
                {
                    var position2 = position;
                    position2.x += x;
                    position2.z += z;
                    var tileGameObject = Instantiate(Block, position2, Quaternion.identity, transform);
                    Grid.AddTile(tileGameObject.GetComponent<TileScript>());
                    tiles.Add(tileGameObject.GetComponent<TileScript>());
                }
            }

            var middle = position;
            middle.x += XSize / 2f;
            middle.z += ZSize / 2f;
            var tile = tiles.FirstOrDefault(x =>
                x.transform.position.x.Equals(middle.x) && x.transform.position.z.Equals(middle.z));
            if (tile != null)
            {
                tile.SpawnPickup(Pickup);
                var tile2 = tiles.FirstOrDefault(x =>
                    x.transform.position.x.Equals(middle.x + XSize/4f) && x.transform.position.z.Equals(middle.z));
                if(tile2!=null)
                    tile2.SpawnPickup(Pickup);
                var tile3 = tiles.FirstOrDefault(x =>
                    x.transform.position.x.Equals(middle.x - XSize/ 4f) && x.transform.position.z.Equals(middle.z));
                if(tile3!=null)
                    tile3.SpawnPickup(Pickup);
            }
            GenerateWalls(position);
                
        }

        public void GenerateWalls(Vector3 position)
        {
            var walls = Grid.GetWalls();
            var doorBase = position;
            doorBase.x += XSize / 2f;
            var wall = walls.FirstOrDefault(x => x.transform.position.Equals(doorBase));
            Grid.AddTile(wall);
            doorBase.x += 1;
            Grid.AddTile(walls.FirstOrDefault(x => x.transform.position.Equals(doorBase)));
            doorBase.x -= 2;
            Grid.AddTile(walls.FirstOrDefault(x => x.transform.position.Equals(doorBase)));
            for (int h = 1; h < 5; h++)
            {
                for (int x = 0; x < XSize; x++)
                {
                    var blockPosition = position;
                    blockPosition.x += x;
                    blockPosition.z += ZSize;
                    blockPosition.y += h;
                    Instantiate(Block, blockPosition, Quaternion.identity, transform);
                }
                for (int x = 0; x < XSize; x++)
                {
                    var blockPosition = position;
                    blockPosition.x += x;
                    blockPosition.y += h;
                    if (x != XSize / 2 && x != XSize / 2+1 && x != XSize / 2 -1 || h>3)
                        Instantiate(Block, blockPosition, Quaternion.identity, transform);
                    else
                        Grid.RemoveTile(blockPosition);
                }

                for (int z = 0; z < ZSize; z++)
                {
                    var blockPosition = position;
                    blockPosition.z += z;
                    blockPosition.y += h;
                    Instantiate(Block, blockPosition, Quaternion.identity, transform);
                }
                for (int z = 0; z < ZSize; z++)
                {
                    var blockPosition = position;
                    blockPosition.x += XSize;
                    blockPosition.z += z;
                    blockPosition.y += h;
                    Instantiate(Block, blockPosition, Quaternion.identity, transform);
                }
            }

        }

        public void CreateDoor(Vector3 position)
        {
            
        }
    }
}

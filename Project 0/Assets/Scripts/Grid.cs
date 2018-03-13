using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Grid : MonoBehaviour
    {
        private List<GameObject> Tiles;
        private List<GameObject> TopTiles;
        public GameObject TilePrefab;
        public GameObject FloorRoot;
        public int max;
        public void Start()
        {
            Generate();
        }
        public void AddTile(GameObject tile)
        {
            this.Tiles.Add(tile);
        }

        public void RemoveTile(GameObject tile)
        {
            if (this.Tiles.Contains(tile))
                this.Tiles.Remove(tile);
        }

        public GameObject GetTileByCoords(float[,] coords)
        {
            return this.Tiles.FirstOrDefault(x => x.GetComponent<Tile>().Coordinates == coords);
        }

        private float GetYByPos(float z, float x)
        {
            var gameObject =
                TopTiles.FirstOrDefault(obj => obj.transform.position.x.Equals(x-1) && (obj.transform.position.z.Equals(z)));
            if (gameObject == null)
                throw new Exception();
            return gameObject.transform.position.y;
        }
        public GameObject GetEmtpyTile()
        {
            bool found = false;
            GameObject tile = null;
            while (!found)
            {
                tile = TopTiles.FirstOrDefault(x => !x.GetComponent<Tile>().HasChild());
                if (tile == null)
                {
                    throw new FileNotFoundException();
                }
                var number = Random.Range(0, TopTiles.Count);
                tile = TopTiles[number];
                if (!tile.GetComponent<Tile>().HasChild())
                    found = true;
                //this.Tiles.FirstOrDefault(x => !x.GetComponent<Tile>().HasChild() && IsTop(x.transform.position.x, x.transform.position.z, x.transform.position.y));
            }

            return tile;
        }
        public void SpawnUnit(GameObject gameObject)
        {
            var tile = GetEmtpyTile();
            var position = tile.transform.position;
            position.y += (float) 1.5;
            Instantiate(gameObject, position, Quaternion.identity, tile.transform);
        }
        public void Generate()
        {
            int yMin = 0;
            int yMax = 2;
            Tiles = new List<GameObject>();
            TopTiles = new List<GameObject>();
            for (int z = 0; z < max; z++)
            {
                int y = 0;
                for (int x = 0; x < max; x++)
                {

                    try
                    {
                        y = (int) GetYByPos(z, x);
                    }
                    catch
                    {
                        
                        //Ignored
                    }
                    yMax = y + 2;
                    yMin = y - 1;
                    if (yMin < 0)
                        yMin = 0;
                    y = Random.Range(yMin, yMax);
                    if (y < 0)
                        y = 0;

                    for (int i = 0; i < y+1; i++)
                                        {
                                            GameObject tile = Instantiate(TilePrefab, new Vector3(x, i, z), Quaternion.identity, FloorRoot.transform);
                                            Tiles.Add(tile);
                                            if (i.Equals(y))
                                            {
                                                TopTiles.Add(tile);
                                            }
                                        }

                }
            }
            Debug.Log("Tiles generated: " + Tiles.Count);
        }
    }
}

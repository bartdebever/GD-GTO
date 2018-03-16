using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class UnitFactory : MonoBehaviour
    {
        public GameObject Prefab;
        public Grid Grid;
        public int InitialSpawns;
        private Player _owner;
        void Start()
        {
            //StartCoroutine(LateStart(2));
        }

        IEnumerator LateStart(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            for (int i = 0; i < InitialSpawns; i++)
            {
                SpawnUnit();
            }
            Debug.Log(InitialSpawns + " Unit spawned");
        }
        public void SpawnUnit()
        {
            this._owner = GetComponentInParent<Player>();
            if (this._owner == null)
                Debug.LogError("Owner not found in Hierancy");
            Grid.SpawnUnit(Prefab, _owner);
        }

        public void SpawnUnit(Tile tile)
        {
            this._owner = GetComponentInParent<Player>();
            if (this._owner == null)
                Debug.LogError("Owner not found in Hierancy");
            Grid.SpawnUnit(Prefab, _owner, tile);
        }
    }
}

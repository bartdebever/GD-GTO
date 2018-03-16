using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public UnitFactory UnitFactory;
    public bool SpawnMode;
    public void Update()
    {
        if (this.SpawnMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var tile = hit.transform.GetComponent<Tile>();
                    UnitFactory.SpawnUnit(tile);
                }
            }
        }
    }
}

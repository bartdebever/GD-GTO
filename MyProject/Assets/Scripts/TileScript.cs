using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject Initialize(float x, float z, float y, Transform transformParent)
    {
        return Instantiate(this.gameObject, new Vector3(x, y, z), Quaternion.identity, transformParent);
    }

    public void SpawnPickup(GameObject pickup)
    {
        var gameObjectPickup = Instantiate(pickup, transform.position, Quaternion.identity, transform);
        gameObjectPickup.transform.Translate(0, 1, 0);
    }
}

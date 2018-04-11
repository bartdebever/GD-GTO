using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<PlayerScript> Players;
	// Use this for initialization
	void Start () {
	    for (int i = 0; i < Game.GetNumberOfPlayers(); i++)
	    {
	        Players[i].gameObject.SetActive(true);
            Game.AddPlayer(Players[i]);
	    }
        Game.GenerateNames();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public KeyCode Up, Down, Left, Right;
    public bool ColorChange = false;
    public bool UsedMove = false;
    public Color BaseColor, BlinkColor;
    public Text MultiplierText;
    public int Health = 3;
    public int Multiplier = 1;
	// Use this for initialization
	void Start () {
		
	}

    public void GetHit(int damage)
    {
        if (damage > 0)
        {
            Health -= damage;
//            if (Health < 0)
//            {
//                Destroy(this.gameObject);
//            }
            UpdateGui();
        }
        
    }

    private void UpdateGui()
    {
        
    }
}

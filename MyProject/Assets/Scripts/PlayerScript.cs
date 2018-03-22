using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [Header("Controls")] public KeyCode Up;
    public KeyCode Down, Left, Right;
    [Header("States")]
    public bool ColorChange = false;
    public bool UsedMove = false;
    [Header("Colors")] public Color BaseColor;
    public Color BlinkColor;
    [Header("UI")]
    public Text MultiplierText;
    public Text HealthText;
    [Header("Base Statistics")]
    public int Health = 3;
    public int Multiplier = 1;

    public int Attack = 1;
	// Use this for initialization
	void Start () {
		
	}

    public void GetHit(int damage)
    {
        if (damage >= 0)
        {
            Health -= damage;
            UpdateGui();
        }
        
    }

    private void UpdateGui()
    {
        HealthText.text = "Health: " + Health;
    }
}

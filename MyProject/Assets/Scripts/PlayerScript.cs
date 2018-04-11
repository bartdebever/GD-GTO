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
    [Header("UI")] public Image Ui;
    public Text healthText;
    private Vector3 moveBuffer = new Vector3(0, 0, 0);

    public delegate void Died();

    public event Died OnDying;
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

        if (Health <= 0)
        {
            if(OnDying != null)
                OnDying();
        }
        
    }

    private void UpdateGui()
    {
        HealthText.text = "Health: " + Health;
    }

    public void SetMovementBuffer(Vector3 movement)
    {
        this.moveBuffer = movement;
    }

    public Vector3 GetMoveBuffer()
    {
        Vector3 result = moveBuffer;
        moveBuffer = new Vector3(0,0,0);
        return result;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManagement : MonoBehaviour
{

    public float Bpm;
    public float Offset;

    public GameObject PlayerGameObject;
    public Color BlinkColor;
    public Button Slider1;
    public Button Slider2;
    public GridContainer grid;
    private KeyCode keyCode;

    private float time;

    private bool moveUsed = false;

    private bool colorChange = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    time += Time.deltaTime;
        Slider1.transform.Translate(0, -(Time.deltaTime * 900 * (1/Bpm)),0);
	    Slider2.transform.Translate(0, (Time.deltaTime * 900 * (1/Bpm)), 0);
        if (time >= Bpm - Offset && !moveUsed)
	    {
	        if (!colorChange)
	        {
	            PlayerGameObject.GetComponent<Renderer>().material.color = BlinkColor;
	            colorChange = true;
	        }
           
	        Vector3 vector = new Vector3(0,0,0);
	        if (Input.GetKeyDown(KeyCode.D))
	        {
	            vector = new Vector3(1,0,0);
            }

	        if (Input.GetKeyDown(KeyCode.S))
	        {
	            vector = new Vector3(0, 0, -1);
            }
	        if (Input.GetKeyDown(KeyCode.W))
	        {
	            vector = new Vector3(0, 0, 1);
	        }
	        if (Input.GetKeyDown(KeyCode.A))
	        {
	            vector = new Vector3(-1, 0, 0);
	        }

	        if (!vector.Equals(new Vector3(0, 0, 0)))
	        {
	            var position = PlayerGameObject.transform.position;
	            position += vector;
	            if (grid.MoveTo(position.x, position.z))
	            {
	                PlayerGameObject.transform.Translate(vector);
                }
	            
	            moveUsed = true;
	        }
	    }

	    if (time >= Bpm)
	    {
	        this.moveUsed = false;
	        this.time = 0.0f;
	        PlayerGameObject.GetComponent<Renderer>().material.color = Color.white;
	        this.colorChange = false;
	        Slider1.transform.position = new Vector3(0, 100, 0);
	        Slider2.transform.position = new Vector3(1920, 100, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBeat : MonoBehaviour
{

    public Image Middle;

    public Image Slider1;

    public Image Slider2;
    public float SecondsPerBeat;
    private List<Vector3> origins = new List<Vector3>();

    private float time = 0;
	// Use this for initialization
	void Start () {
		origins.Add(Slider1.transform.position);
        origins.Add(Slider2.transform.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    time += Time.deltaTime;
	    if (time >= SecondsPerBeat - 0.2)
	    {
	        try
	        {
	            Middle.color = Color.red;
	            Slider1.color = Color.red;
	            Slider2.color = Color.red;
	        }
	        catch
	        {
	            //Shut up Unity, this works and thats good enough
	        }

	    }
	    if (time >= SecondsPerBeat)
	    {
	        Slider1.transform.position = origins[0];
	        Slider2.transform.position = origins[1];
	        time = 0;
	        try
	        {
	            Middle.color = Color.white;
	            Slider1.color = Color.white;
	            Slider2.color = Color.white;
            }
	        catch
	        {
	            //Shut up Unity, this works and thats good enough
	        }

        }
        Slider1.transform.Translate(7.5f * 1/SecondsPerBeat,0,0);
	    Slider2.transform.Translate(-7.5f * 1 / SecondsPerBeat, 0, 0);
    }
}

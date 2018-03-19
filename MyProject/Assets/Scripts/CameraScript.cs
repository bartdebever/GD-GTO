using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera Camera1, Camera2;

    public bool SplitScreen;
	// Use this for initialization
	void Start () {
	    if (!SplitScreen)
	    {
            Camera1.rect = new Rect(0,0,1,1);
	        Camera2.enabled = false;
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        ChangeScreen();
	    }
	}

    void ChangeScreen()
    {
        if (!SplitScreen)
        {
            Camera1.rect = new Rect(0, 0, 0.5f, 1);
            Camera2.enabled = true;
            SplitScreen = true;
        }
        else
        {
            Camera1.rect = new Rect(0,0,1,1);
            Camera2.enabled = false;
            SplitScreen = false;
        }
    }
}

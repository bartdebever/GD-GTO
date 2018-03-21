using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraScript : MonoBehaviour
{
    public Camera Camera1, Camera2;
    public Image PausePanel;
    [Tooltip("Indicates if the game will start in split-screen mode.")]
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
	    if (Input.GetKeyDown(KeyCode.Escape))
	    {
	        if (Game.IsRunning())
	        {
	            Game.Pause();
	            PausePanel.gameObject.SetActive(true);
            }

	        else
	        {
	            Game.Play();
	            PausePanel.gameObject.SetActive(false);
	        }
                

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

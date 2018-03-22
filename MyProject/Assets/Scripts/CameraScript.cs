using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraScript : MonoBehaviour
{
    public Camera Camera1, Camera2, PauseCamera;
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
	            PauseCamera.gameObject.SetActive(true);
                Game.SetCurrentCamera(PauseCamera);
            }

	        else
	        {
	            Game.Play();
	            PausePanel.gameObject.SetActive(false);
                PauseCamera.gameObject.SetActive(false);
                Game.SetCurrentCamera(null);
	        }
                

        }

	    if (!Game.IsRunning())
	    {
	        var d = Input.GetAxis("Mouse ScrollWheel");
	        if (d > 0f)
	        {
	            PauseCamera.transform.Translate(0,0,2);
	        }
	        else if (d < 0f)
	        {
	            PauseCamera.transform.Translate(0, 0, -2);
            }

	        if (Input.GetKeyDown(KeyCode.W))
	        {
                PauseCamera.transform.Translate(0,2,0);
	        }
	        if (Input.GetKeyDown(KeyCode.S))
	        {
	            PauseCamera.transform.Translate(0, -2, 0);
	        }
	        if (Input.GetKeyDown(KeyCode.D))
	        {
	            PauseCamera.transform.Translate(2, 0, 0);
	        }
	        if (Input.GetKeyDown(KeyCode.A))
	        {
	            PauseCamera.transform.Translate(-2, 0, 0);
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

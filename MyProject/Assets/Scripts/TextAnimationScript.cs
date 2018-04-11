using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimationScript : MonoBehaviour
{

    public Text FlyingText;
    public Vector3 start;
    public Vector3 destination;
    public float totalTime;

    private Vector3 increments;
    private bool playAnimation = false;

    private float time = 0;
	// Use this for initialization
	void Start ()
    { 
        Debug.Log(increments);
    }
	
	// Update is called once per frame
	void Update () {
	    if (playAnimation)
	    {
	        time += Time.deltaTime;
	        float xIncrement = (destination.x - start.x) * (time / totalTime);
	        float yIncrement = (destination.y - start.y) * (time / totalTime);
	        float zIncrement = (destination.y - start.z) * (time / totalTime);
	        increments = new Vector3(xIncrement, yIncrement, zIncrement);
            if (time <= totalTime)
	        {
	            FlyingText.transform.Translate(increments);
	        }
	        if (time >= totalTime)
	        {
	            time = 0;
	            playAnimation = false;
	        }
	    }
	}

    public void PlayAnimation()
    {
        this.playAnimation = true;
    }
}

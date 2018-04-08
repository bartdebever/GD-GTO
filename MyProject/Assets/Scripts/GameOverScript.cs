using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

    public Text WinnerText;

    public string WinnerPrefix = "The winner is: ";

    private bool gameOver = false;

    private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (gameOver)
	    {
	        if (timer >= 5f)
	        {
	            gameOver = false;
                Game.Restart();
	        }
	        else
	        {
	            timer += Time.deltaTime;
	        }
	    }
	}

    public void SetWinnerText(string text)
    {
        WinnerText.text = WinnerPrefix + text;
        timer = 0f;
        gameOver = true;
    }
}

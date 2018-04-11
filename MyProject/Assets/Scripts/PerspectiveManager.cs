using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PerspectiveManager : MonoBehaviour
{
    private List<PlayerScript> players;
    public Camera PauseCamera;
    public bool UsePauseCamera = false;
    public Image PausePanel;
    public Image OptionsPanel;
    public Image GameOverPanel;
    public Image PlayerDefeated;
    [Tooltip("Indicates if the game will start in split-screen mode.")]
    public bool SplitScreen;

    private bool gameOver = false;
    private bool playerDied = false;
    private float diedTimer = 0f;
    private bool initialized = false;
	// Use this for initialization
	void Start ()
	{

	}
	// Update is called once per frame
	void Update ()
	{
	    if (playerDied && diedTimer >= 1f)
	    {
            PlayerDefeated.gameObject.SetActive(false);
	        diedTimer = 0f;
	        playerDied = false;
            Game.Play();
	    }
	    else if(playerDied)
	    {
	        diedTimer += Time.deltaTime;
	    }
	    players = Game.GetPlayers();
	    if (!initialized && players!=null)
	    {
	        players = Game.GetPlayers();
	        if (!SplitScreen)
	        {
	            players[0].GetComponentInChildren<Camera>().rect = new Rect(0, 0, 1, 1);
	            for (int i = 1; i < players.Count; i++)
	            {
	                players[i].GetComponentInChildren<Camera>().enabled = false;
	            }
	        }
	        foreach (var playerScript in players)
	        {
	            playerScript.OnDying += PlayerDied;
	        }

	        initialized = true;
	    }
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        ChangeScreen();
	    }
	    if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
	    {
	        if (Game.IsRunning())
	        {
	            PauseGame();
	        }

	        else
	        {
	           PlayGame();
	        }
                

        }

	    if (!Game.IsRunning() && !gameOver)
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
	        if (Input.GetKey(KeyCode.W))
	        {
                PauseCamera.transform.Translate(0,2,0);
	        }
	        if (Input.GetKey(KeyCode.S))
	        {
	            PauseCamera.transform.Translate(0, -2, 0);
	        }
	        if (Input.GetKey(KeyCode.D))
	        {
	            PauseCamera.transform.Translate(2, 0, 0);
	        }
	        if (Input.GetKey(KeyCode.A))
	        {
	            PauseCamera.transform.Translate(-2, 0, 0);
	        }
        }
	}

    void ChangeScreen()
    {
        if (!SplitScreen)
        {
            float width = 1f / players.Count;
            float height = 1f;
            float y = 0;
            float x = 0;
            if ((players.Count / 4f).Equals(1f))
            {
                height = 0.5f;
                width = 0.5f;
            }
            foreach (var player in players)
            {
                try
                {
                    if (player != null)
                    {
                        var camera = player.GetComponentInChildren<Camera>();
                        camera.rect = new Rect(x, y, width, height);
                        camera.enabled = true;
                        x += width;
                        player.Ui.gameObject.SetActive(true);
                    }
                }
                catch { }


                if ((players.Count / 4f).Equals(1f) && x.Equals(1f))
                {
                    x = 0f;
                    y += height;
                }
            }
            SplitScreen = true;
        }
        else
        {
            players[0].GetComponentInChildren<Camera>().rect = new Rect(0, 0, 1, 1);
            for (int i = 0; i < players.Count; i++)
            {
                if(i>0)
                    players[i].GetComponentInChildren<Camera>().enabled = false;
                players[i].Ui.gameObject.SetActive(false);
            }
            SplitScreen = false;
        }
    }

    public void PlayGame()
    {
        Game.Play();
        PausePanel.gameObject.SetActive(false);
        OptionsPanel.gameObject.SetActive(false);
        if (UsePauseCamera)
        {
            PauseCamera.gameObject.SetActive(false);
            Game.SetCurrentCamera(null);
        }

    }

    void PauseGame()
    {
        Game.Pause();
        PausePanel.gameObject.SetActive(true);
        if (UsePauseCamera)
        {
           
            PauseCamera.gameObject.SetActive(true);
            Game.SetCurrentCamera(PauseCamera);
        }

    }

    public void OpenOptions()
    {
        PausePanel.gameObject.SetActive(false);
        OptionsPanel.gameObject.SetActive(true);
    }

    public void CloseOptions()
    { 
        PausePanel.gameObject.SetActive(true);
        OptionsPanel.gameObject.SetActive(false);
    }

    private void OnDeath()
    {
        int deadPlayer;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] == null)
                deadPlayer = i;
        }
        //Prepare Game over screen
        GameOver();
    }

    private void GameOver()
    {
        CloseOptions();
        PauseCamera.gameObject.SetActive(true);
        Game.SetCurrentCamera(PauseCamera);
        GameOverPanel.gameObject.SetActive(true);
        gameOver = true;
        PauseGame();
        var playerWonIndex = -1;
        var players = Game.GetPlayers();
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].Health > 0)
            {
                playerWonIndex = i;
                break;
            }
        }
        GameOverPanel.GetComponent<GameOverScript>().SetWinnerText(players[playerWonIndex].gameObject.name);
    }

    private void PlayerDied()
    {
        if (players.Count == 2)
        {
            GameOver();
        }

        int deadPlayerIndex = -1;
        for (int i = 0; i < players.Count; i++)
        {
            try
            {
                if (players[i].Health <= 0)
                {
                    deadPlayerIndex = i;
                }
            }
            catch
            {
                deadPlayerIndex = i;
            }
        }

        if (deadPlayerIndex != -1)
        {
            if (players.Count > 2)
                PlayerDiedPopup(players[deadPlayerIndex].gameObject.name);
            players.RemoveAt(deadPlayerIndex);

        }

        if (SplitScreen)
        {
            float width = 1f / players.Count;
            float height = 1f;
            float y = 0;
            float x = 0;
            if ((players.Count / 4f).Equals(1f))
            {
                height = 0.5f;
                width = 0.5f;
            }
            foreach (var player in players)
            {
                try
                {
                    if (player != null)
                    {
                        var camera = player.GetComponentInChildren<Camera>();
                        camera.rect = new Rect(x, y, width, height);
                        camera.enabled = true;
                        x += width;
                    }
                }
                catch { }


                if ((players.Count / 4f).Equals(1f) && x.Equals(1f))
                {
                    x = 0f;
                    y += height;
                }
            }
        }
    }

    private void PlayerDiedPopup(string playerName)
    {
        playerDied = true;
        Game.Pause();
        PlayerDefeated.gameObject.SetActive(true);
        PlayerDefeated.gameObject.GetComponentInChildren<Text>().text = playerName + " defeated!";
        //PlayerDefeated.GetComponent<TextAnimationScript>().PlayAnimation();
    }
}

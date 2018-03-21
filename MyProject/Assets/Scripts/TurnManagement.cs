using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public List<PlayerScript> Players;
    public Text MultiplierDisplay;
    private float time;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update()
	{
	    if (Game.IsRunning())
	    {
            time += Time.deltaTime;
            Slider1.transform.Translate(0, -(Time.deltaTime * 900 * (1 / Bpm)), 0);
            Slider2.transform.Translate(0, (Time.deltaTime * 900 * (1 / Bpm)), 0);
            foreach (var player in Players)
            {
                if (time >= Bpm - Offset && !player.UsedMove)
                {
                    if (!player.ColorChange)
                    {
                        player.gameObject.GetComponent<Renderer>().material.color = player.BlinkColor;
                        player.ColorChange = true;
                    }

                    Vector3 vector = new Vector3(0, 0, 0);
                    if (Input.GetKeyDown(player.Right))
                    {
                        vector = new Vector3(1, 0, 0);
                    }

                    if (Input.GetKeyDown(player.Down))
                    {
                        vector = new Vector3(0, 0, -1);
                    }
                    if (Input.GetKeyDown(player.Up))
                    {
                        vector = new Vector3(0, 0, 1);
                    }
                    if (Input.GetKeyDown(player.Left))
                    {
                        vector = new Vector3(-1, 0, 0);
                    }

                    if (!vector.Equals(new Vector3(0, 0, 0)))
                    {
                        var position = player.gameObject.transform.position;
                        position += vector;
                        var playerHit = Players.FirstOrDefault(x =>
                            x.gameObject.transform.position.x.Equals(position.x) && x.gameObject.transform.position.z.Equals(position.z));

                        if (grid.MoveTo(position.x, position.z) && playerHit == null)
                        {
                            player.gameObject.transform.Translate(vector);
                        }
                        else if (playerHit != null)
                        {
                            playerHit.GetHit(1);
                            if (playerHit.Health < 0)
                            {
                                Destroy(playerHit.gameObject);
                                Players.Remove(playerHit);
                                break;
                            }
                        }

                        player.UsedMove = true;
                        if (player.Multiplier <= 2)
                            player.Multiplier++;
                        UpdateGui(player.MultiplierText, player.Multiplier);
                    }
                }
                else if (Input.anyKeyDown)
                {
                    player.Multiplier = 1;
                    UpdateGui(player.MultiplierText, player.Multiplier);
                }

                if (time >= Bpm)
                {
                    if (!player.UsedMove)
                    {
                        player.Multiplier = 1;
                        UpdateGui(player.MultiplierText, player.Multiplier);
                    }
                    player.UsedMove = false;
                    if (this.Players.IndexOf(player) == Players.Count - 1)
                    {
                        this.time = 0.0f;
                        Slider1.transform.position = new Vector3(0, 100, 0);
                        Slider2.transform.position = new Vector3(1920, 100, 0);
                    }

                    player.gameObject.GetComponent<Renderer>().material.color = player.BaseColor;
                    player.ColorChange = false;

                }

            }
        }


        
    }

    void UpdateGui(Text text, int amount)
    {
        text.text = "Multiplier: " + amount;
    }

}

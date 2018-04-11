using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Slider PlayerSlider;

    public Text PlayerCount;

    public List<GameObject> PlayerSlots;

    public Toggle SoundToggle;
	// Use this for initialization
	void Start () {
		PlayerSlider.onValueChanged.AddListener(delegate
		{
		    PlayerCount.text = PlayerSlider.value.ToString();
		    for (int i = 0; i < PlayerSlider.value; i++)
		    {
		        PlayerSlots[i].SetActive(true);
		    }
		    for (int i =(int) PlayerSlider.value; i < PlayerSlots.Count; i++)
		    {
		        PlayerSlots[i].SetActive(false);
		    }
		});
	    PlayerSlider.value = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGame()
    {
        var nameList = new List<string>();
        foreach (var playerSlot in PlayerSlots)
        {
            nameList.Add(playerSlot.GetComponentInChildren<InputField>().text);
        }
        Game.SetPlayerNames(nameList);
        Game.SetNumberOfPlayers((int) PlayerSlider.value);
        Game.SetPlayAudio(SoundToggle.isOn);
        SceneManager.LoadScene("Main");
    }
}

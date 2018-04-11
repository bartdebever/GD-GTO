using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game
{
    private static bool running = true;
    private static Camera currrentCamera;
    private static List<PlayerScript> players;
    private static List<string> playerNames = new List<string>();
    private static int numberOfPlayers = 0;
    private static bool playAudio = false;

    public static void SetNumberOfPlayers(int amount)
    {
        numberOfPlayers = amount;
    }

    public static void SetPlayerNames(List<string> names)
    {
        playerNames = names;
    }
    public static int GetNumberOfPlayers()
    {
        return numberOfPlayers;
    }
    public static bool IsRunning()
    {
        return running;
    }

    public static void Pause()
    {
        running = false;
    }

    public static void Play()
    {
        running = true;
    }

    public static Camera GetCurrentCamera()
    {
        if(currrentCamera == null)
            return Camera.main;
        return currrentCamera;
    }

    public static void SetCurrentCamera(Camera camera)
    {
        currrentCamera = camera;
    }

    public static List<PlayerScript> GetPlayers()
    {
        return players;
    }

    public static void RemovePlayer(int index)
    {
        if(players!=null)
            players.RemoveAt(index);
    }

    public static void RemovePlayer(PlayerScript player)
    {
        if (players != null)
            players.Remove(player);
    }

    public static void AddPlayer(PlayerScript player)
    {
        if (players == null)
            players = new List<PlayerScript>();
        players.Add(player);
    }

    public static void AddPlayers(List<PlayerScript> addPlayers)
    {
        if (players == null)
            players = addPlayers;
        else
            players.AddRange(players);
    }

    public static void Restart()
    {
        players = null;
        Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void GenerateNames()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].gameObject.name = playerNames[i];
        }
    }

    public static bool PlayAudio()
    {
        return playAudio;
    }

    public static void SetPlayAudio(bool value)
    {
        playAudio = value;
    }
}

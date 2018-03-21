using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    private static bool running = false;

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
}

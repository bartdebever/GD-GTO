using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    private static bool running = true;
    private static Camera currrentCamera;
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
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {
    public void ResumeGame()
    {
        Game.Play();
    }
}

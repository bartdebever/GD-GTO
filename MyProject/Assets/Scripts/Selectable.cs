﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public bool IsSelected;
    public Color BaseColor, SelectedColor;

    public void OnSelected()
    {
        this.gameObject.GetComponent<Renderer>().material.color = SelectedColor;
    }

    public void OnDeselected()
    {
        this.gameObject.GetComponent<Renderer>().material.color = BaseColor;
    }
}

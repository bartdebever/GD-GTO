using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceModel : MonoBehaviour
{
    public string name;
    public float amount;
    public string description;
    public float initial;
    public float max;
    public delegate void ValueChanged();
    public event ValueChanged OnValueChanged;

    public void Trigger()
    {
        if (OnValueChanged != null)
        {
            OnValueChanged();
        }
    }
}

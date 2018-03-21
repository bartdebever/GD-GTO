using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public bool IsSelected;

    public void OnSelected()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public void OnDeselected()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}

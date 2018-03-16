using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOwned : MonoBehaviour {

    private Player _owner;
    public Renderer ColorRenderer;

    public Player Owner
    {
        get { return this._owner; }
        set { this._owner = value; }
    }

    public void SetMaterial()
    {
        if (_owner != null && ColorRenderer != null)
        {
            this.ColorRenderer.material.color = _owner.Color;
        }
    }
}

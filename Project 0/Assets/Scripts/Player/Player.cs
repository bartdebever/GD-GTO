using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Color Color;
    private bool isDead;

    public virtual void TurnStart()
    {
        gameObject.SetActive(true);
    }

    public virtual void TurnEnd()
    {
        gameObject.SetActive(false);
    }
}

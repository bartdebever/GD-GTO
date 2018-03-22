using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [Header("Statistics")]
    public int Attack;
    public int Health, Movement;
    [Header("Properties")]
    public int Durability;
    public bool PickedUp;
    [Header("Shop")]
    public int Cost;

    public string Name, Description;
}

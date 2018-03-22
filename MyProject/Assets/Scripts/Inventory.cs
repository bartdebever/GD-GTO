using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemScript> Items;

    public void AddItem(ItemScript item)
    {
        Items.Add(item);
    }

    public void HasItem(Type type)
    {
        
    }
}

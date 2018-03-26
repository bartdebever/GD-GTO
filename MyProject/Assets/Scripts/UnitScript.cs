using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public int Health;
    public int Attack;
    public int Movement;
    public int DiggingPower;
    public List<ItemScript> Inventory;
    private int baseHealth;
    private int baseAttack;
    private int baseMovement;
    private int baseDigPower;

    void Start()
    {
        this.baseAttack = Attack;
        this.baseHealth = Health;
        this.baseDigPower = DiggingPower;
        this.baseMovement = Movement;
    }
    public void GetHit(int damage)
    {
        if (damage > 0)
        {
            Health -= damage;
        }
    }

    public void Upgrade(ItemScript item)
    {
        if (item.Attack > 0)
            Attack = baseAttack + item.Attack;
        if (item.Health > 0)
            Health = Health + item.Health;
        if (item.Movement > 0)
            Movement = baseMovement + item.Movement;
        if (item.Attack > 0)
            DiggingPower = baseDigPower + item.DigPower;
        if (Inventory == null)
            Inventory = new List<ItemScript>();
        Inventory.Add(item);
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public bool Collides(Vector3 position)
    {
        return gameObject.transform.position.Equals(position);
    }
}

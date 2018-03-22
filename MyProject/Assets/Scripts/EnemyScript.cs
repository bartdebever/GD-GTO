using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Statistics")]
    public int Health;
    public int Attack;
    public int Movement;
    public MoveType MovementType;
    public int MovementStatus = 0;
    public GameObject Initialize(float x, float z, float y, Transform transformParent)
    {
        return Instantiate(this.gameObject, new Vector3(x, y, z), Quaternion.identity,transformParent);
    }

    public void GetHit(int damage)
    {
        if (damage > 0)
            Health -= damage;
    }
}

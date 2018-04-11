using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Statistics")]
    public int Health=2;
    public int Attack;
    public int Movement;
    public MoveType MovementType;
    public int MovementStatus = 0;
    private bool stagger = false;
    private int staggerTime = 0;

    private Color baseColor;
    public Color StaggerColor;
    public GameObject Initialize(float x, float z, float y, Transform transformParent)
    {
        return Instantiate(this.gameObject, new Vector3(x, y, z), Quaternion.identity,transformParent);
    }

    public void GetHit(int damage)
    {
        if (damage > 0)
        {
            Health -= damage;
            if (!stagger)
            {
                stagger = true;
                this.baseColor = this.gameObject.GetComponent<Renderer>().material.color;
                this.gameObject.GetComponent<Renderer>().material.color = StaggerColor;
            }
                
        }
            
    }

    public bool IsStaggered()
    {
        return stagger;
    }

    public void RemoveStagger()
    {
        if (staggerTime > 0)
        {
            stagger = false;
            this.gameObject.GetComponent<Renderer>().material.color = baseColor;
        }
        staggerTime++;
    }
}

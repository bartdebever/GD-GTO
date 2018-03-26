﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private List<EnemyScript> enemies;
    private List<EnemyScript> bufferEnemies;
    public GridContainer Grid;
    public void MoveEnemies()
    {
        bufferEnemies = enemies;
        foreach (var enemy in enemies)
        { 
            try
            {
                switch (enemy.MovementType)
                {
                    case MoveType.LeftRight:
                        if (enemy.MovementStatus == 1)
                        {
                            enemy.transform.Translate(0, 0, 1);

                        }

                        enemy.MovementStatus++;
                        if (enemy.MovementStatus > 3)
                        {
                            enemy.transform.Translate(0, 0, -1);
                            enemy.MovementStatus = 0;
                        }
                        break;
                }
            }
            catch (MissingReferenceException ex)
            {
            }
        }
        enemies = bufferEnemies;
    }

    public void AddEnemy(EnemyScript enemy)
    {
        if(enemies == null)
            enemies = new List<EnemyScript>();
        enemies.Add(enemy);
    }
}
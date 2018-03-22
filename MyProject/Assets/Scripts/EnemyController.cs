using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private List<EnemyScript> enemies;
    public void MoveEnemies()
    {
        foreach (var enemy in enemies)
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
    }

    public void AddEnemy(EnemyScript enemy)
    {
        if(enemies == null)
            enemies = new List<EnemyScript>();
        enemies.Add(enemy);
    }
}

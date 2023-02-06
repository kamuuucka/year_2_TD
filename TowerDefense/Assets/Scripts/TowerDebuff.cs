// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class TowerDebuff : Tower
// {
//     [SerializeField] private TowerAttack towerRange;
//     private List<Enemy> enemiesT;
//     
//     void Update()
//     {
//         enemiesT = towerRange.GetEnemies();
//          
//         foreach (var enemy in enemiesT)
//         {
//             //Debug.Log("slowing down: " + enemy);
//             enemy.SetSpeed(enemy.GetSpeed() - 1.0f);
//         }
//     }
// }
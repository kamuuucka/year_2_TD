// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class TowerSingle : Tower
// {
//     [SerializeField] private TowerAttack towerRange;
//     private Transform enemyT;
//     private float timer;
//     [SerializeField]
//     private List<Enemy> _enemies;
//     private bool toRemove = false;
//     private void Start()
//     {
//         towerRange = GetComponentInChildren<TowerAttack>();
//     }
//
//     protected virtual void Update()
//     {
//         //UpgradeTower();
//         _enemies = towerRange.GetEnemies();
//         Debug.Log(towerRange.EnemyInRange);
//         if (timer > 0.5f && towerRange.EnemyInRange > 0)
//         {
//             Debug.Log("shooting at: " + _enemies[0].name);
//             //_enemies[0].AttackEnemy(GetDamage());
//             timer = 0;
//         }
//         timer += Time.deltaTime;
//     }
//
//     public TowerAttack GetTowerRange()
//     {
//         return towerRange;
//     }
//
//     public Transform GetEnemyTransform()
//     {
//         return enemyT;
//     }
// }

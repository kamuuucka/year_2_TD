using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerArea : Tower
{
    [SerializeField] private TowerAttack towerRange;
    private float timer;
    private List<Enemy> enemiesT;
    private void Start()
    {
        //damage = DamageType.area;
        towerRange = GetComponentInChildren<TowerAttack>();
    }

    private void Update()
    {
        enemiesT = towerRange.GetTransforms();

        if (timer > 2f && towerRange.EnemyInRange)
        {
            timer = 0;
            foreach (var enemy in enemiesT)
            {
                enemy.AttackEnemy(GetDamage());
            }
        }
        
        timer += Time.deltaTime;
    }
}

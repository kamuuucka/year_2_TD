using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerArea : Tower
{
    [SerializeField] private TowerAttack towerRange;
    private Transform enemyT;
    private float timer;
    private void Start()
    {
        damage = DamageType.single;
        towerRange = GetComponentInChildren<TowerAttack>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f && towerRange.EnemyInRange)
        {
            Debug.Log("REady to shoot");
            timer = 0;
            towerRange.EnemyT().GetComponentInParent<Enemy>().AttackEnemy(GetDamage());
        }
    }
}

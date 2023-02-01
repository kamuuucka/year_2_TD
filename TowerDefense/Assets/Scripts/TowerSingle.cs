using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSingle : Tower
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private TowerAttack towerRange;
    private Transform enemyT;
    private float timer;
    private void Start()
    {
        //price = 50;
        damage = DamageType.single;
        towerRange = GetComponentInChildren<TowerAttack>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1f && towerRange.EnemyInRange)
        {
            Debug.Log("REady to shoot");
            timer = 0;
            enemyT = towerRange.EnemyT();
            enemyT.GetComponentInParent<Enemy>().AttackEnemy(10);
        }
    }

    private void ShootBullet()
    {
        GameObject newBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet.transform.parent = gameObject.transform;
    }

    public TowerAttack GetTowerRange()
    {
        return towerRange;
    }

    public Transform GetEnemyTransform()
    {
        return enemyT;
    }
}

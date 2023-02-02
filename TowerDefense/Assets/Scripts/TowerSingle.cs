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
    private List<Enemy> _enemies;// = new List<Enemy>();
    private void Start()
    {
        towerRange = GetComponentInChildren<TowerAttack>();
    }

    private void Update()
    {
        _enemies = towerRange.GetTransforms();
        if (timer > 0.5f && towerRange.EnemyInRange)
        {
            Debug.Log(_enemies[0].name);
            timer = 0;
            if (_enemies[0].GetDead())
            {
                Debug.Log(_enemies[0].name + " died");
                //_enemies.Remove(_enemies[0]);
            }
            _enemies[0].AttackEnemy(GetDamage());
            Debug.Log("shooting at: " + _enemies[0].name);
            
            //enemyT = towerRange.EnemyT();
            //enemyT.GetComponentInParent<Enemy>().AttackEnemy(10);
        }
        
        timer += Time.deltaTime;
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

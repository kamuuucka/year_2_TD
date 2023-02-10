using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private TowerAttack towerRange;
    public ITowersDamage _towersDamage;
    private float timer;

    private int singleTowerPrice = 0;
    private int areaTowerPrice = 0;
    private int debuffTowerPrice = 0;

    public void SetTowerRange(TowerAttack towerAttack)
    {
        towerRange = towerAttack;
    }

    private void Update()
    {
        if (timer > 0.5f)
        {
            if (towerRange != null)
            {
                _towersDamage?.Use(towerRange);
            }
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}

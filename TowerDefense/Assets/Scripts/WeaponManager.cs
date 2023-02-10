using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private int upgradePrice;
    private TowerAttack towerRange;
    public ITowersDamage _towersDamage;
    private float timer;

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
        //Debug.Log("Upgrade tower price: " + upgradePrice);
        
    }
    
    //Used to mark when tower can be bought -
    //needs a link with inventory manager -
    //through level manager or by just adding prefab to the inventory manager
    public int GetPrice()
    {
        return price;
    }

    public int GetUpgradePrice()
    {
        return upgradePrice;
    }

    public void SetUpgradePrice(int price)
    {
        upgradePrice += price;
    }
}

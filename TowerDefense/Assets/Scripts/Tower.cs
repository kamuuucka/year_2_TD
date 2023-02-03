using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected int price;
    [SerializeField] protected int upgradePrice;
    [SerializeField] private GameObject upgrade;
    protected bool upgradeAvailable = false;
    protected bool upgraded = false;

    protected enum DamageType
    {
        single,
        area,
        special
    }

    [SerializeField] protected DamageType damage;
    protected int damageValue = 0;

    public int GetPrice()
    {
        return price;
    }

    private void Update()
    {
       
    }

    public int GetDamage()
    {
        switch (damage)
        {
            case DamageType.single:
                damageValue = 10;
                break;
            case DamageType.area:
                damageValue = 15;
                break;
            case DamageType.special:
                damageValue = 0;
                break;
            default:
                break;
        }

        return damageValue;
    }

    protected void UpgradeTower()
    {
        upgradeAvailable = LevelManager.Instance.Upgrade();
        
        if (upgradeAvailable)
        {
            Debug.Log("You can afford an upgrade!");
            upgrade.SetActive(true);
        }
        
        if (upgraded)
        {
            upgraded = false;
            upgradePrice += 50;
        }
    }
}

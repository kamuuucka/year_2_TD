using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerType type;
    [SerializeField] protected int price;
    [SerializeField] protected int upgradePrice;
    [SerializeField] private GameObject upgrade;
    [SerializeField] private TowerAttack towerRange;
    protected bool upgradeAvailable = false;
    protected bool upgraded = false;

    private ITowersDamage _towersDamage;
    private float timer;

    public ITowersDamage _currentDamage
    {
        get => _towersDamage;
        set => _towersDamage = value;
    }

    public int GetPrice()
    {
        return price;
    }

    private void Update()
    {
        if (timer > type.GetWaitingTime())
        {
            if (type.GetDamage() == TowerType.DamageType.single)
            {
                _currentDamage = new TowerSingleDamage();
                _currentDamage?.Use(towerRange);
                timer = 0;
            }
            if (type.GetDamage() == TowerType.DamageType.area)
            {
                _currentDamage = new TowerAreaDamage();
                _currentDamage?.Use(towerRange);
                timer = 0;
            }
            if (type.GetDamage() == TowerType.DamageType.special)
            {
                _currentDamage = new TowerDebuffDamage();
                _currentDamage?.Use(towerRange);
                timer = 0;
            }
        }
        
        timer += Time.deltaTime;
    }

    // public int GetDamage()
    // {
    //     switch (damage)
    //     {
    //         case DamageType.single:
    //             damageValue = 10;
    //             break;
    //         case DamageType.area:
    //             damageValue = 15;
    //             break;
    //         case DamageType.special:
    //             damageValue = 0;
    //             break;
    //         default:
    //             break;
    //     }
    //
    //     return damageValue;
    // }

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

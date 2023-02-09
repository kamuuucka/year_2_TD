using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [HideInInspector][SerializeField] private int price;
    [SerializeField] private int upgradePrice;
    [SerializeField] private GameObject upgrade;
    [SerializeField] private TowerAttack towerRange;

    protected bool upgradeAvailable = false;
    protected bool upgraded = false;

    public ITowersDamage _towersDamage;
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
        if (timer > 0.5f)
        {
            _towersDamage?.Use(towerRange);
            timer = 0;
        }

        timer += Time.deltaTime;
        
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

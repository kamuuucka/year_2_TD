using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for setting the towers' weapon
/// </summary>
public class WeaponManager : MonoBehaviour
{
    [SerializeField] private int damage;
    protected ITowersDamage TowersDamage;
    private TowerRange _towerRange;
    private float _timer;

    public void SetTowerRange(TowerRange towerAttack)
    {
        _towerRange = towerAttack;
    }

    public void UpgradeTower(int addition)
    {
        TowersDamage?.Upgrade(addition);
    }

    private void Update()
    {
        if (_timer > 0.5f)
        {
            if (_towerRange != null)
            {
                TowersDamage?.Use(_towerRange, damage);
            }
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }
}

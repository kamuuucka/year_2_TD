using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackSingle : WeaponManager
{
    public TowerAttackSingle()
    {
        _towersDamage = new TowerSingleDamage();
    }
}

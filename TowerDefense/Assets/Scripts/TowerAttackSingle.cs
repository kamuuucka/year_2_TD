using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackSingle : Tower
{
   
   public TowerAttackSingle()
    {
        _towersDamage = new TowerSingleDamage();
    }
}

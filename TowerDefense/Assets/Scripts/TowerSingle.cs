using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSingle : Tower
{
    private void Start()
    {
        price = 50;
        damage = DamageType.single;
    }
}

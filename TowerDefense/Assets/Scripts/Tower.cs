using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected int price;

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

    public int GetDamage()
    {
        switch (damage)
        {
            case DamageType.single:
                damageValue = 10;
                break;
            case DamageType.area:
                damageValue = 5;
                break;
            case DamageType.special:
                damageValue = 0;
                break;
            default:
                break;
        }

        return damageValue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerType")]
public class TowerType : ScriptableObject
{
    [SerializeField] private int price;

    private enum DamageType
    {
        single,
        area,
        special
    }

    [SerializeField] private DamageType damage;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerType")]
public class TowerType : ScriptableObject
{
    public enum DamageType
    {
        single,
        area,
        special
    }

    [SerializeField] private DamageType damage;
    [SerializeField] private float waitTime;

    public DamageType GetDamage()
    {
        return damage;
    }

    public float GetWaitingTime()
    {
        return waitTime;
    }
}
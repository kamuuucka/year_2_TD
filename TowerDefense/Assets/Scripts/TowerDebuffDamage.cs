using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface responsible for debuff tower
/// </summary>
public class TowerDebuffDamage : ITowersDamage
{
    private int slowDown;
    private List<Enemy> _enemies;

    public void Use(TowerRange range, int damage)
    {
        slowDown = damage;
        _enemies = range.GetEnemies();
        foreach (Enemy enemy in _enemies)
        {
            enemy.SetSpeed(enemy.GetSpeed() - slowDown);
        }
    }

    public void Upgrade(int addition)
    {
        slowDown += addition / 10;
    }
}
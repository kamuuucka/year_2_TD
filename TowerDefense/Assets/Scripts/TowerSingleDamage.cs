using System.Collections.Generic;

/// <summary>
/// Interface responsible for single tower
/// </summary>
public class TowerSingleDamage : ITowersDamage
{
    private int _damage;
    private List<Enemy> _enemies;

    public void Use(TowerRange range, int damage)
    {
        _damage = damage;
        _enemies = range.GetEnemies();
        if (range.EnemyInRange > 0)
        {
            _enemies[0].AttackEnemy(_damage);
        }
    }

    public void Upgrade(int addition)
    {
        _damage += addition;
    }
}
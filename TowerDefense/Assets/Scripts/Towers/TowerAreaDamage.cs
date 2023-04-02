using System.Collections.Generic;

/// <summary>
/// Interface of area tower
/// </summary>
public class TowerAreaDamage : ITowersDamage
{
    private int _damage;
    private List<Enemy> _enemies;

    public void Use(TowerRange range, int damage)
    {
        _damage = damage;
        _enemies = range.GetEnemies();
        foreach (Enemy enemy in _enemies)
        {
            enemy.AttackEnemy(_damage);
        }
    }

    public void Upgrade(int addition)
    {
        _damage += addition;
    }
}
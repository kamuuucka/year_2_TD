    
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TowerAreaDamage : ITowersDamage
    {
        private int damage = 15;
        private List<Enemy> _enemies;
        public void Use(TowerAttack range)
        {
            _enemies = range.GetEnemies();
            foreach (Enemy enemy in _enemies)
            {
                enemy.AttackEnemy(damage);
            }
        }
    }

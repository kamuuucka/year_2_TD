
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class TowerSingleDamage : ITowersDamage
    {
        private int damage = 10;
        private List<Enemy> _enemies;
        public void Use(TowerAttack range)
        {
            _enemies = range.GetEnemies();
            if (range.EnemyInRange > 0)
            {
                Debug.Log("shooting at: " + _enemies[0].name);
                _enemies[0].AttackEnemy(damage);
            }
        }
    }

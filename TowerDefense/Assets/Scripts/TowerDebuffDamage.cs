using System.Collections.Generic;
using UnityEngine;


    public class TowerDebuffDamage : ITowersDamage
    {
        [SerializeField]private List<Enemy> _enemies;
        public void Use(TowerAttack range)
        {
            _enemies = range.GetEnemies();
            foreach (Enemy enemy in _enemies)
            {
                
                enemy.SetSpeed(enemy.GetSpeed() - 1.0f);
            }
        }
    }

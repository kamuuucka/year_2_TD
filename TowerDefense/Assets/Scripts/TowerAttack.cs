using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{ 
    public int EnemyInRange
    {
        get
        {
            return enemyInRange;
        }
    }

    private int enemyInRange = 0;
    private float timer;
    private float timeBetweenAttacks = 0.5f;
    private Transform rangeT;
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        timer = 0f;
        _enemies.Add(col.gameObject.GetComponent<Enemy>());
        enemyInRange++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enemyInRange--;
        _enemies.Remove(other.gameObject.GetComponent<Enemy>());
        other.gameObject.GetComponent<Enemy>().ResetSpeed();
    }

    public List<Enemy> GetEnemies()
    {
        return _enemies;
    }
}
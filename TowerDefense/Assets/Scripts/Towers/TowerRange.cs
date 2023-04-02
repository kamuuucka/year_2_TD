using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Class responsible for detecting enemies in towers' range
/// </summary>
public class TowerRange : MonoBehaviour
{
    public int EnemyInRange => _enemyInRange;
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();

    private int _enemyInRange;
    private Transform _rangeT;

    private void OnTriggerEnter2D(Collider2D col)
    {
        enemies.Add(col.gameObject.GetComponent<Enemy>());
        _enemyInRange++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _enemyInRange--;
        enemies.Remove(other.gameObject.GetComponent<Enemy>());
        other.gameObject.GetComponent<Enemy>().ResetSpeed();
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }
}
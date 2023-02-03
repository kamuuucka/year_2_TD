using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private Collider2D range;
    private Transform rangeT;
    private Enemy enemy;

    [SerializeField]
    private List<Enemy> _enemies = new List<Enemy>();

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

    // Start is called before the first frame update
    void Start()
    {
        range = gameObject.GetComponentInChildren<Collider2D>();
        //Debug.Log(range.gameObject.name);
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        timer = 0f;
        enemy = col.gameObject.GetComponent<Enemy>();
        //Debug.Log(col.gameObject);
        _enemies.Add(col.gameObject.GetComponent<Enemy>());
        //Debug.Log("After adding: " + _enemies.Count);
        enemyInRange++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enemyInRange--;
        _enemies.Remove(other.gameObject.GetComponent<Enemy>());
        other.gameObject.GetComponent<Enemy>().ResetSpeed();
        //Debug.Log("After removing: " + _enemies.Count);
    }

    public Transform EnemyT()
    {
        if (enemy != null)
        {
            return enemy.transform;
        }
        else
        {
            return null;
        }
    }

    public List<Enemy> GetTransforms()
    {
        return _enemies;
    }

    public void RemoveFromTheList()
    {
        if (_enemies != null)
        {
            _enemies.RemoveAt(0);
        }
    }
}
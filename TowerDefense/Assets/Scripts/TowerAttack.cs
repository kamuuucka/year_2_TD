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

    public bool EnemyInRange
    {
        get
        {
            return enemyInRange;
        }
    }

    private bool enemyInRange;
    private float timer;
    private float timeBetweenAttacks = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        range = gameObject.GetComponentInChildren<Collider2D>();
        Debug.Log(range.gameObject.name);
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        timer = 0f;
        enemy = col.gameObject.GetComponent<Enemy>();
        enemyInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enemyInRange = false;
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
}
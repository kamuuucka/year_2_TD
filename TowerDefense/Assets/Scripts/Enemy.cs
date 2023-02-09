using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float maxHealth = 0;
    [SerializeField]
    protected float speed = 0;
    [SerializeField]
    private float health = 0;
    [SerializeField]
    protected int money = 0;

   
    
    private Transform[] waypoints;
    private int waypoint = 0;

    public HealthBar healthBar;
    private float attackPower;
    private float oldSpeed;
    private bool last;
    private bool slowedDown;

    private bool dead = false;

    void Start()
    {
        oldSpeed = speed;
        health = maxHealth;
        waypoints = LevelManager.Instance.GetWaypoints().waypoints;
        healthBar.SetHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoint == waypoints.Length)
        {
            LevelManager.Instance.SetLives(1);
            LevelManager.Instance.SetNumberOfEnemies(-1);
            waypoint = 0;
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypoint].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints[waypoint].position) < 0.01f)
        {
            waypoint++;
        }
        
        if (health <= 0)
        {
            dead = true;
            LevelManager.Instance.SetMoney(money);
            LevelManager.Instance.SetNumberOfEnemies(-1);
            Destroy(gameObject);
        }

        if (slowedDown)
        {
            ResetSpeed();
        }
    }

    public void AttackEnemy(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health, maxHealth);
    }

    public float GetSpeed()
    {
        return oldSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        
        speed = newSpeed;
        slowedDown = true;
    }

    public void ResetSpeed()
    {
        speed = oldSpeed;
        slowedDown = false;
    }
}

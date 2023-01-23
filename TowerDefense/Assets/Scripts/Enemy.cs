using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float maxHealth = 0;
    [SerializeField]
    protected float speed = 0;
    private float health = 0;
    [SerializeField]
    protected int money = 0;
    
    private Transform[] waypoints;
    private int waypoint = 0;

    public HealthBar healthBar;
    private float attackPower;

    //TODO: HEALTHBAR
    // Start is called before the first frame update
    void Start()
    {
        
        health = maxHealth;
        waypoints = LevelManager.Instance.GetWaypoints().waypoints;
        healthBar.SetHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoint == waypoints.Length)
        {
            LevelManager.Instance.SetEnemiesReachedGoal();
            Debug.Log("Enemy reached the end");
            Destroy(gameObject);
            waypoint = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypoint].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints[waypoint].position) < 0.01f)
        {
            waypoint++;
        }
        
        if (health <= 0)
        {
            LevelManager.Instance.SetMoney(money);
            Destroy(gameObject);
        }
    }

    public void AttackEnemy(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health, maxHealth);
        Debug.Log(gameObject + "'s health: " + health);
    }
}

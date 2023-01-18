using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static float maxHealth = 30;
    public float speed;
    public static float health;
    public int money;
    
    private Transform[] waypoints;
    private int waypoint = 0;

    public HealthBar healthBar;
    private float attackPower;

    // Start is called before the first frame update
    void Start()
    {
        attackPower = LevelManager.Instance.Attack(5);
        
        health = maxHealth;
        waypoints = LevelManager.Instance.GetWaypoints().waypoints;
        healthBar.SetHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoint == waypoints.Length)
        {
            LevelManager.Instance.SetEnemiesReachedGoal(1);
            Debug.Log("Enemy reached the end");
            Destroy(gameObject);
            waypoint = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypoint].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints[waypoint].position) < 0.01f)
        {
            waypoint++;
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            health -= attackPower;
            healthBar.SetHealth(health, maxHealth);
            Debug.Log(gameObject + "'s health: " + health);
        }

        if (health <= 0)
        {
            LevelManager.Instance.SetMoney(money);
            Destroy(gameObject);
        }
    }
}

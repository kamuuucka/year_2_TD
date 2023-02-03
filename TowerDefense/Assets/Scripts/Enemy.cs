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
    public bool slowedDown;

    private bool dead = false;

    //TODO: HEALTHBAR
    // Start is called before the first frame update
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
            
            Destroy(gameObject);
            LevelManager.Instance.SetLives(1);
            waypoint = 0;
            if (last)
            {
                //Debug.Log("End of the wave");
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypoint].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints[waypoint].position) < 0.01f)
        {
            waypoint++;
        }
        
        if (health <= 0)
        {
            if (last)
            {
                //Debug.Log("End of the wave");
            }
            dead = true;
            LevelManager.Instance.SetMoney(money);
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
       // Debug.Log(gameObject + "'s health: " + health);
    }

    public float GetSpeed()
    {
        return oldSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        //Debug.Log(speed);
        slowedDown = true;
    }

    public void ResetSpeed()
    {
        speed = oldSpeed;
        slowedDown = false;
    }

    public void SetLast()
    {
        last = true;
    }

    public bool GetDead()
    {
        return dead;
    }

    public float GetHealth()
    {
        return health;
    }
}

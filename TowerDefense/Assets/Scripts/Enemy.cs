using UnityEngine;

/// <summary>
/// Enemy class responsible for enemies
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    
    [SerializeField] private float maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private int money;

    private Transform[] _waypoints;
    private int _waypoint;
    private float _attackPower;
    private float _oldSpeed;
    private bool _last;
    private bool _slowedDown;

    void Start()
    {
        _oldSpeed = speed;
        health = maxHealth;
        _waypoints = LevelManager.Instance.GetWaypoints().waypoints;
        healthBar.SetHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (_waypoint == _waypoints.Length)
        {
            LevelManager.Instance.SetLives(1);
            LevelManager.Instance.RemoveEnemy();
            _waypoint = 0;
            Destroy(gameObject);
        }
        
        transform.position = Vector2.MoveTowards(
            transform.position,
            _waypoints[_waypoint].position,
            speed * Time.deltaTime
            );
        
        if (Vector2.Distance(transform.position, _waypoints[_waypoint].position) < 0.01f)
        {
            _waypoint++;
        }
        
        if (health <= 0)
        {
            LevelManager.Instance.SetMoney(money);
            LevelManager.Instance.RemoveEnemy();
            Destroy(gameObject);
        }

        if (_slowedDown)
        {
            ResetSpeed();
        }
    }

    /// <summary>
    /// Method to attack enemies
    /// </summary>
    /// <param name="damage"></param>
    public void AttackEnemy(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health, maxHealth);
    }

    /// <summary>
    /// Method to take enemies' speed, used to slow them down in TowerDebuffDamage
    /// </summary>
    /// <returns>float _oldSpeed</returns>
    public float GetSpeed()
    {
        return _oldSpeed;
    }

    /// <summary>
    /// Method to change enemies' speed, used to slow them down in TowerDebuffDamage
    /// </summary>
    /// <param name="newSpeed"></param>
    public void SetSpeed(float newSpeed)
    {
        
        speed = newSpeed;
        _slowedDown = true;
    }

    /// <summary>
    /// Method used to reset enemies' speed
    /// </summary>
    public void ResetSpeed()
    {
        speed = _oldSpeed;
        _slowedDown = false;
    }
}

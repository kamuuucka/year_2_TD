using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Level manager responsible for gameplay
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    
    [SerializeField] private int money = 150;
    [SerializeField] private int lives = 5;
    [SerializeField] private float timer = 30.0f;
    
    private int _wave;
    private int _enemiesOnBoard = 1;
    private Waypoints _waypoints;
    private bool _upgrade;
    private bool _waveStart;
    private bool _waveInProgress;
    private float _setTime;
    
    
    private void Awake()
    {
        Instance = this;
        _setTime = timer;
    }
    
    void Start()
    {
        _waypoints = GetComponentInChildren<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_waveInProgress)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _waveStart = true;
                _waveInProgress = true;
                timer = _setTime;
            }
        }
        else
        {
            timer = _setTime;
        }

        if (_enemiesOnBoard <= 0 && _waveInProgress)
        {
            _waveInProgress = false;
            _wave++;
        }

        if (lives <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    /// <summary>
    /// Method used to share the wave number with other objects
    /// </summary>
    /// <returns></returns>
    public int GetWave()
    {
        return _wave;
    }
    
    /// <summary>
    /// Method used to share the waypoint list with other objects
    /// </summary>
    /// <returns></returns>
    public Waypoints GetWaypoints()
    {
        return _waypoints;
    }

    /// <summary>
    /// Method used to share the money number with other objects
    /// </summary>
    /// <returns></returns>
    public int GetMoney()
    {
        return money;
    }

    /// <summary>
    /// Method used to update the money variable
    /// </summary>
    /// <param name="money"></param>
    public void SetMoney(int money)
    {
        this.money += money;
    }

    /// <summary>
    /// Method used to share the lives number with other objects
    /// </summary>
    /// <returns></returns>
    public int GetLives()
    {
        return lives;
    }

    /// <summary>
    /// Method used to update the lives variable
    /// </summary>
    /// <param name="lives"></param>
    public void SetLives(int lives)
    {
        this.lives -= lives;
    }

    /// <summary>
    /// Method used to share the wave start with other objects
    /// </summary>
    /// <returns></returns>
    public bool GetWaveStart()
    {
        return _waveStart;
    }

    /// <summary>
    /// Method used to update the wave start
    /// </summary>
    /// <param name="value"></param>
    public void SetWaveStart(bool value)
    {
        _waveStart = value;
    }
    
    /// <summary>
    /// Method used to share the wave in progress with other objects
    /// </summary>
    /// <returns></returns>
    public bool GetWaveInProgress()
    {
        return _waveInProgress;
    }

    /// <summary>
    /// Method used to update the wave in progress
    /// </summary>
    /// <param name="value"></param>
    public void SetWaveInProgress(bool value)
    {
        _waveInProgress = value;
    }

    /// <summary>
    /// Method used to share the time with other objects
    /// </summary>
    /// <returns></returns>
    public float GetTime()
    {
        return timer;
    }

    /// <summary>
    /// Method used to change the number of enemies in the game
    /// </summary>
    /// <param name="number"></param>
    public void SetNumberOfEnemies(int number)
    {
        _enemiesOnBoard = number;
    }

    /// <summary>
    /// Method used to change the number of enemies in the game
    /// </summary>
    public void RemoveEnemy()
    {
        _enemiesOnBoard--;
    }
}

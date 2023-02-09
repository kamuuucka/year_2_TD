using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    
    private int wave = 0;
    private int money = 0;
    private int lives = 5;

    private float timer = 5.0f;

    private Waypoints waypoints;
    private bool upgrade = false;
    private int enemiesOnBoard = 0;
    public bool waveStart = false;
    public bool waveInProgress = false;
    public bool buyPhase = false;
    private int singleTowerPrice = 0;
    
    

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GetComponentInChildren<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(singleTowerPrice);
        if (!waveInProgress)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                waveStart = true;
                timer = 60.0f;
            }
        }

        if (enemiesOnBoard <= 0)
        {
            waveInProgress = false;
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            wave++;
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            money+=50;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            money--;
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            upgrade = true;
        }

        if (lives <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public int GetWave()
    {
        return wave;
    }

    public int GetMoney()
    {
        return money;
    }

    public Waypoints GetWaypoints()
    {
        return waypoints;
    }

    public void SetMoney(int money)
    {
        this.money += money;
    }

    public int GetLives()
    {
        return lives;
    }

    public void SetLives(int lives)
    {
        this.lives -= lives;
    }

    public float GetTime()
    {
        return timer;
    }

    public void ResetTime()
    {
        timer = 90.0f;
    }

    public bool Upgrade()
    {
        Debug.Log(upgrade);
        return upgrade;
    }

    public int GetNumberOfEnemies()
    {
        return enemiesOnBoard;
    }

    public void SetNumberOfEnemies(int number)
    {
        enemiesOnBoard += number;
        //Debug.Log("Enemies in the game: " + enemiesOnBoard);
        
    }

    public int GetSingleTowerPrice()
    {
        return singleTowerPrice;
    }

    public void SetSingleTowePrice(int towerPrice)
    {
        this.singleTowerPrice = towerPrice;
    }
}

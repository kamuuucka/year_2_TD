using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    
    private int wave = 0;
    private int money = 0;

    private Waypoints waypoints;

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
        if (Input.GetKeyUp(KeyCode.L))
        {
            wave++;
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            money++;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            money--;
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
}

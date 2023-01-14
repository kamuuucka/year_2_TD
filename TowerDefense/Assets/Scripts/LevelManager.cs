using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int wave = 0;
    private int money = 0;
    
    // Start is called before the first frame update
    void Start()
    {
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
}

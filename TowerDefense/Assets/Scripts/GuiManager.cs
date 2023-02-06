using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GuiManager : MonoBehaviour
{
    public TMP_Text waveNumber;
    public TMP_Text moneyNumber;
    public TMP_Text livesNumber;
    public TMP_Text timeNumber;
    public GameObject inventory;

    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        waveNumber.text = "Wave: " + levelManager.GetWave();
        moneyNumber.text = "Money: " + levelManager.GetMoney();
        livesNumber.text = "Lives left: " + levelManager.GetLives();

        float minutes = Mathf.FloorToInt(levelManager.GetTime() / 60);
        float seconds = Mathf.FloorToInt(levelManager.GetTime() % 60);

        timeNumber.text = string.Format("{0:00}:{1:00}", minutes,seconds);

        if (levelManager.waveInProgress)
        {
            inventory.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    public TMP_Text waveNumber;
    public TMP_Text moneyNumber;
    public TMP_Text livesNumber;
    public TMP_Text timeNumber;

    public LevelManager _levelManager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        waveNumber.text = "Wave: " + _levelManager.GetWave();
        moneyNumber.text = "Money: " + _levelManager.GetMoney();
        livesNumber.text = "Lives left: " + _levelManager.GetLives();

        float minutes = Mathf.FloorToInt(_levelManager.GetTime() / 60);
        float seconds = Mathf.FloorToInt(_levelManager.GetTime() % 60);

        timeNumber.text = string.Format("{0:00}:{1:00}", minutes,seconds);
    }
}

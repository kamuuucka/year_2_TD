using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    public TMP_Text waveNumber;
    public TMP_Text moneyNumber;

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
    }
}

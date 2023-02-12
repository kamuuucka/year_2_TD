using TMPro;
using UnityEngine;

/// <summary>
/// Class responsible for changes in the UI
/// </summary>
public class GuiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text waveNumber;
    [SerializeField] private TMP_Text moneyNumber;
    [SerializeField] private TMP_Text livesNumber;
    [SerializeField] private TMP_Text timeNumber;
    
    [SerializeField] private GameObject inventory;
    [SerializeField] private LevelManager levelManager;

    // Update is called once per frame
    void Update()
    {
        waveNumber.text = "Wave: " + (levelManager.GetWave() + 1);
        moneyNumber.text = "Money: " + levelManager.GetMoney();
        livesNumber.text = "Lives left: " + levelManager.GetLives();

        float minutes = Mathf.FloorToInt(levelManager.GetTime() / 60);
        float seconds = Mathf.FloorToInt(levelManager.GetTime() % 60);

        timeNumber.text = $"{minutes:00}:{seconds:00}";

        inventory.SetActive(!levelManager.GetWaveInProgress());
    }
}

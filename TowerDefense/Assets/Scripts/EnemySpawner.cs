using System.Collections;
using UnityEngine;

/// <summary>
/// Class responsible for spawning enemies and setting up levels
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveDefinition[] levels;
    private int _waveNumber;
   

    // Update is called once per frame
    void Update()
    {
        _waveNumber = LevelManager.Instance.GetWave();
        if (!LevelManager.Instance.GetWaveInProgress())
        {
            LevelManager.Instance.SetNumberOfEnemies(levels[_waveNumber].numberOfFastEnemies + levels[_waveNumber].numberOfSlowEnemies);
        }
        if (Input.GetKeyUp(KeyCode.Return) || LevelManager.Instance.GetWaveStart())
        {
            
            LevelManager.Instance.SetWaveStart(false);
            LevelManager.Instance.SetWaveInProgress(true);
            StartCoroutine(SpawnEnemies(levels[_waveNumber].enemyFast, levels[_waveNumber].waitTime, levels[_waveNumber].numberOfFastEnemies));
            StartCoroutine(SpawnEnemies(levels[_waveNumber].enemySlow, levels[_waveNumber].waitTime, levels[_waveNumber].numberOfSlowEnemies));
        }
    }

    /// <summary>
    /// Spawn enemies after a delay
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="waitTime"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    IEnumerator SpawnEnemies(GameObject enemy, float waitTime, int count)
    {
        int enemySpawned = 0;
        while (enemySpawned < count)
        {
            GameObject newEnemy = Instantiate(enemy, this.transform.position, Quaternion.identity);
            newEnemy.transform.SetParent(this.transform);
            newEnemy.name += enemySpawned;
            yield return new WaitForSeconds(waitTime);
            enemySpawned++;
        }
    }
}

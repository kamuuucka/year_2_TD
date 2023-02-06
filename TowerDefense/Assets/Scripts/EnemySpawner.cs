using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public WaveDefinition[] levels;
    public int waveNumber = 0;
    private bool lastEnemy = false;

    //private int enemySpawned = 0;

    private int enemiesOnBoard = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return) || LevelManager.Instance.waveStart){
            lastEnemy = false;
            LevelManager.Instance.waveStart = false;
            LevelManager.Instance.waveInProgress = true;
            enemiesOnBoard = 0;
            StartCoroutine(SpawnEnemies(levels[waveNumber].enemyFast, levels[waveNumber].waitTime, levels[waveNumber].numberOfFastEnemies));
            StartCoroutine(SpawnEnemies(levels[waveNumber].enemySlow, levels[waveNumber].waitTime, levels[waveNumber].numberOfSlowEnemies));
        }
    }

    IEnumerator SpawnEnemies(GameObject enemy, float waitTime, int count)
    {
        int enemySpawned = 0;
        while (enemySpawned < count)
        {
            LevelManager.Instance.SetNumberOfEnemies(1);
            Debug.Log("Start spawning " + count + " enemies. Enemy: " + enemySpawned);
            GameObject newEnemy = Instantiate(enemy, this.transform.position, Quaternion.identity);
            newEnemy.transform.SetParent(this.transform);
            newEnemy.name += enemySpawned;
            yield return new WaitForSeconds(waitTime);
            enemySpawned++;
        }
        Debug.Log("No more enemies");
    }
}

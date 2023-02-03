using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public WaveDefinition[] levels;
    public int waveNumber = 0;
    private bool lastEnemy = false;

    private int enemySpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return)){
            //Debug.Log("WAVE: " + waveNumber);
            lastEnemy = false;
            StartCoroutine(SpawnEnemies(levels[waveNumber].enemyFast, levels[waveNumber].waitTime, levels[waveNumber].numberOfFastEnemies, false));
            StartCoroutine(SpawnEnemies(levels[waveNumber].enemySlow, levels[waveNumber].waitTime, levels[waveNumber].numberOfSlowEnemies, true));
        }
    }

    IEnumerator SpawnEnemies(GameObject enemy, float waitTime, int count, bool hasLastEnemy)
    {
        //Debug.Log("Start spawning enemies");
        enemySpawned = 0;
        while (enemySpawned < count)
        {
            GameObject newEnemy = Instantiate(enemy, this.transform.position, Quaternion.identity);
            newEnemy.transform.SetParent(this.transform);
            newEnemy.name += enemySpawned;
            if (enemySpawned + 1 == count)
            {
                newEnemy.GetComponent<Enemy>().SetLast();
            }
            yield return new WaitForSeconds(waitTime);
            enemySpawned++;
        }

        // if (hasLastEnemy)
        // {
        //     waveNumber++;
        //     lastEnemy = true;
        // }
    }

    public bool GetLastEnemy()
    {
        return lastEnemy;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public WaveDefinition[] levels;
    
    
    public GameObject enemy;
    public int waveNumber = 0;

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            count = 0;
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (count < waveNumber)
        {
            GameObject newEnemy = Instantiate(enemy, this.transform.position, Quaternion.identity);
            newEnemy.transform.SetParent(this.transform);
            yield return new WaitForSeconds(2f);
            count++;
        }

        
    }
}

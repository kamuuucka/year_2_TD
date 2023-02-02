using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Wave")]
public class WaveDefinition : ScriptableObject
{
    public GameObject enemySlow;
    public GameObject enemyFast;
    public float waitTime;
    public int numberOfSlowEnemies;
    public int numberOfFastEnemies;
}

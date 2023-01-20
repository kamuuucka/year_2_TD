using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Wave")]
public class WaveDefinition : ScriptableObject
{
    public Enemy enemyPrefab;
    public int count;
    public float delay;
}

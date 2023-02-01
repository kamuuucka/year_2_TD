using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDebuff : Tower
{
    [SerializeField] private TowerAttack towerRange;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (towerRange.EnemyInRange)
        {
            if (!towerRange.EnemyT().GetComponentInParent<Enemy>().slowedDown)
            {
                towerRange.EnemyT().GetComponentInParent<Enemy>().SetSpeed(1.5f);
            }
            
        }
    }
}

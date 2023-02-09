using System;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    
    [SerializeField] private int upgradePrice;
    [SerializeField] private GameObject upgrade;
    [SerializeField] private TowerAttack towerRange;
    [SerializeField] private WeaponManager _weaponManager;

    public bool upgradeAvailable = true;
    private bool upgraded = false;
    private float timer;

    private void Start()
    {
        _weaponManager.SetTowerRange(towerRange);
    }

    private void Update()
    {
        
    }

    
    
    // protected void UpgradeTower()
    // {
    //     upgradeAvailable = LevelManager.Instance.Upgrade();
    //     
    //     if (upgradeAvailable)
    //     {
    //         Debug.Log("You can afford an upgrade!");
    //         upgrade.SetActive(true);
    //     }
    //     
    //     if (upgraded)
    //     {
    //         upgraded = false;
    //         upgradePrice += 50;
    //     }
    // }
}
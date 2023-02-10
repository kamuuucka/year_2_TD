using System;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    
    //[SerializeField] private int upgradePrice;
    [SerializeField] private GameObject upgrade;
    [SerializeField] private TowerAttack towerRange;
    [SerializeField] private WeaponManager _weaponManager;
    [SerializeField] private int upgradeJump;

    private bool upgradeAvailable = false;
    private bool upgraded = false;
    private float timer;

    private void Start()
    {
        _weaponManager.SetTowerRange(towerRange);
    }

    private void Update()
    {
        Debug.Log("Your money: "+LevelManager.Instance.GetMoney());
        Debug.Log("Tower upgrade price: " +_weaponManager.GetUpgradePrice());
        // if (LevelManager.Instance.GetMoney() >= _weaponManager.GetUpgradePrice())
        // {
        //     //Debug.Log("upgrade available");
        //     upgradeAvailable = true;
        // }
        // else
        // {
        //     upgradeAvailable = false;
        // }
    }

    public bool GetTowerUpgrade()
    {
        return upgradeAvailable;
    }

    public void Upgrade()
    {
        upgraded = true;
    }
    
    public void UpgradeTower()
    {
        upgradeAvailable = LevelManager.Instance.Upgrade();
        
        if (upgradeAvailable)
        {
            Debug.Log("You can afford an upgrade!");
            upgrade.SetActive(true);
        }
        
        if (upgraded)
        {
            upgraded = false;
            upgrade.SetActive(false);
            _weaponManager.SetUpgradePrice(50);
        }
    }
}
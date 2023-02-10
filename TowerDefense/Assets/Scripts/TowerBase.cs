using System;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    
    //[SerializeField] private int upgradePrice;
    [SerializeField] private GameObject upgrade;
    [SerializeField] private TowerAttack towerRange;
    [SerializeField] private WeaponManager _weaponManager;
    [SerializeField] private int upgradeJump;
    [SerializeField] private int price;
    [SerializeField] private int upgradePrice;

    private bool upgradeAvailable = false;
    private bool upgraded = false;
    private float timer;

    private void Start()
    {
        _weaponManager.SetTowerRange(towerRange);
    }

    private void Update()
    {
        //Debug.Log("Your money: "+LevelManager.Instance.GetMoney());
        //Debug.Log("Tower upgrade price: " +_weaponManager.GetUpgradePrice());
         if (LevelManager.Instance.GetMoney() >= upgradePrice)//_weaponManager.GetUpgradePrice())
         {
             //Debug.Log("upgrade available");
             upgradeAvailable = true;
             upgrade.SetActive(true);
         }
         else
         {
             upgradeAvailable = false;
         }
         
         if (upgraded)
         {
             LevelManager.Instance.SetMoney((-upgradePrice));
             upgraded = false;
             upgrade.SetActive(false);
             upgradePrice += upgradeJump;
         }
    }
    public int GetPrice()
    {
        return price;
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
        
    }
}
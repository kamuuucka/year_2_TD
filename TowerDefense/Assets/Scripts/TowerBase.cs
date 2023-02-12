using System;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Class responsible for base of a tower
/// </summary>
public class TowerBase : MonoBehaviour
{
    
    //[SerializeField] private int upgradePrice;
    [SerializeField] private GameObject upgrade;
    [SerializeField] private TowerRange towerRange;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private int upgradeJump;
    [SerializeField] private int price;
    [SerializeField] private int upgradePrice;

    private bool _upgradeAvailable;
    private bool _upgraded;
    private float _timer;

    private void Start()
    {
        weaponManager.SetTowerRange(towerRange);
    }

    private void Update()
    {
         if (LevelManager.Instance.GetMoney() >= upgradePrice)
         {
             _upgradeAvailable = true;
             upgrade.SetActive(true);
         }
         else
         {
             _upgradeAvailable = false;
             upgrade.SetActive(false);
         }
         
         if (_upgraded)
         {
             LevelManager.Instance.SetMoney(-upgradePrice);
             _upgraded = false;
             upgrade.SetActive(false);
             upgradePrice += upgradeJump;
             weaponManager.UpgradeTower(10);
         }
    }
    public int GetPrice()
    {
        return price;
    }
    public bool GetTowerUpgrade()
    {
        return _upgradeAvailable;
    }

    public void Upgrade()
    {
        _upgraded = true;
    }
}
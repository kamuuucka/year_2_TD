using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class responsible for showing towers on the inventory slot
/// </summary>
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Image slot1;
    [SerializeField] private Image slot2;
    [SerializeField] private Image slot3;

    private int _singleTowerPrice;
    private int _areaTowerPrice;
    private int _debuffTowerPrice;
    
    void Update()
    {
        //tower debuff
        if (LevelManager.Instance.GetMoney() >= _debuffTowerPrice)
        {
            slot3.color = new Vector4(0, 0.7f, 1, 1);
        }
        else
        {
            slot3.color = new Vector4(0.5f, 0.5f, 0.5f, 1); 
        }

        //tower area
        if(LevelManager.Instance.GetMoney() >= _areaTowerPrice)
        {
            slot2.color = new Vector4(0.5f, 0, 1, 1);
        }
        else
        {
            slot2.color = new Vector4(0.5f, 0.5f, 0.5f, 1);
        }
        
        //tower single
        if(LevelManager.Instance.GetMoney() >= _singleTowerPrice)
        {
            slot1.color = new Vector4(1, 0.5f, 0, 1);
        }
        else
        {
            slot1.color = new Vector4(0.5f, 0.5f, 0.5f, 1);
        }
    }

    /// <summary>
    /// Method used for the first setup of prices
    /// </summary>
    /// <param name="singleTowerPrice"></param>
    /// <param name="areaTowerPrice"></param>
    /// <param name="debuffTowerPrice"></param>
    public void SetUpPrices(int singleTowerPrice, int areaTowerPrice, int debuffTowerPrice)
    {
        _singleTowerPrice = singleTowerPrice;
        _areaTowerPrice = areaTowerPrice;
        _debuffTowerPrice = debuffTowerPrice;
    }
    
}

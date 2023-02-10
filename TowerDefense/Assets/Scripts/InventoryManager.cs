using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Image slot1;
    public Image slot2;
    public Image slot3;

    private int singleTowerPrice;
    private int areaTowerPrice;
    private int debuffTowerPrice;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tower debuff
        if (LevelManager.Instance.GetMoney() >= debuffTowerPrice)
        {
            slot3.color = new Vector4(0.4f, 0.1f, 0.4f, 1);
        }
        else
        {
            slot3.color = new Vector4(0.4f, 0.1f, 0.4f, 0.2f); 
        }

        //tower area
        if(LevelManager.Instance.GetMoney() >= areaTowerPrice)
        {
            slot2.color = new Vector4(0, 1, 0.2f, 1);
        }
        else
        {
            slot2.color = new Vector4(0, 1, 0.2f, 0.2f);
        }
        
        //tower single
        if(LevelManager.Instance.GetMoney() >= singleTowerPrice)
        {
            slot1.color = new Vector4(1, 1f, 1f, 1);
        }
        else
        {
            slot1.color = new Vector4(1, 1f, 1f, 0.2f);
        }
    }

    public void SetUpPrices(int singleTowerPrice, int areaTowerPrice, int debuffTowerPrice)
    {
        this.singleTowerPrice = singleTowerPrice;
        this.areaTowerPrice = areaTowerPrice;
        this.debuffTowerPrice = debuffTowerPrice;
    }
    
}

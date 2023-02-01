using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Image slot1;
    public Image slot2;
    public Image slot3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.GetMoney() >= 100)
        {
            slot3.color = new Vector4(0.4f, 0.1f, 0.4f, 1);
        }

        else if(LevelManager.Instance.GetMoney() >= 50)
        {
            slot2.color = new Vector4(0, 1, 0.2f, 1);
            slot1.color = new Vector4(1, 1f, 1f, 1);
            slot3.color = new Vector4(0.4f, 0.1f, 0.4f, 0.2f); ;
        }

        else
        {
            slot2.color = new Vector4(0, 1, 0.2f, 0.2f);
            slot1.color = new Vector4(1, 1f, 1f, 0.2f);
            slot3.color = new Vector4(0.4f, 0.1f, 0.4f, 0.2f); ;
        }
    }
}

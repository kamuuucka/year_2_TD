using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveableObject : MonoBehaviour
{
    public GameObject selectedObject;
    public GameObject towerSingle;
    public GameObject towerArea;
    public GameObject towerDebuff;
    Vector3Int cellPosition;
    public Grid grid;
    public GameObject hover;
    public GameObject range;
    private int layerIgnoreRaycast;
    private int layerPlayer;

    private int singleTowerPrice;
    private int areaTowerPrice;
    private int debuffTowerPrice;

    public LayerMask raycastLayer;
    public InventoryManager inventoryManager;

    private void Start()
    {
        layerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        layerPlayer = LayerMask.NameToLayer("Player");
        singleTowerPrice = towerSingle.GetComponent<TowerBase>().GetPrice();
        areaTowerPrice = towerArea.GetComponent<TowerBase>().GetPrice();
        debuffTowerPrice = towerDebuff.GetComponent<TowerBase>().GetPrice();
        inventoryManager.SetUpPrices(
            singleTowerPrice,
            areaTowerPrice,
            debuffTowerPrice
            );
    }
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //this event is active when you are pointing over the UI
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (!selectedObject)
            {
                Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                if (targetObject)
                {
                    selectedObject = targetObject.transform.gameObject;
                    hover = selectedObject.transform.GetChild(0).gameObject;
                    selectedObject.layer = layerIgnoreRaycast;
                    hover.SetActive(true);
                }
            } 
            else
            {
                selectedObject.transform.position = grid.GetCellCenterLocal(cellPosition);
                hover.transform.position = grid.GetCellCenterLocal(cellPosition);
                hover.SetActive(false);
                selectedObject.layer = layerPlayer;
                selectedObject = null;
                hover = null;
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            if (!selectedObject)
            {
                Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                Debug.Log(targetObject.name);
                if (targetObject.GetComponent<TowerBase>().GetTowerUpgrade())
                {
                    Debug.Log("Upgrading");
                    targetObject.GetComponent<TowerBase>().Upgrade();
                }
            }
        }
        if (selectedObject)
        {
           // Debug.Log("Yes selected object");
            Collider2D lookForTowers = Physics2D.OverlapPoint((mousePosition), raycastLayer);
            //Debug.Log("Look for tower" + lookForTowers);
             if (lookForTowers)
             {
                //Debug.Log("There's already a tower here ");
             }
             else
             {
                cellPosition = grid.LocalToCell(mousePosition);
                hover.transform.position = grid.GetCellCenterLocal(cellPosition);
            }
            
        }  
    }

    //Used in buttons
    public void SpawnTowerSingle()
    {
        Debug.Log("Spwning single attack tower");
        LevelManager.Instance.SetMoney(-singleTowerPrice);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject newTower = Instantiate(towerSingle, mousePosition, Quaternion.identity);
        selectedObject = newTower;
        selectedObject.layer = layerIgnoreRaycast;
        hover = selectedObject.transform.GetChild(0).gameObject;
        hover.SetActive(true);
    }

    public void SpawnTowerArea()
    {
        LevelManager.Instance.SetMoney(-areaTowerPrice);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject newTower = Instantiate(towerArea, mousePosition, Quaternion.identity);
        selectedObject = newTower;
        selectedObject.layer = layerIgnoreRaycast;
        hover = selectedObject.transform.GetChild(0).gameObject;
        hover.SetActive(true);
    }

    public void SpawnTowerDebuff()
    {
        LevelManager.Instance.SetMoney(-debuffTowerPrice);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject newTower = Instantiate(towerDebuff, mousePosition, Quaternion.identity);
        selectedObject = newTower;
        selectedObject.layer = layerIgnoreRaycast;
        hover = selectedObject.transform.GetChild(0).gameObject;
        hover.SetActive(true);
    }
}

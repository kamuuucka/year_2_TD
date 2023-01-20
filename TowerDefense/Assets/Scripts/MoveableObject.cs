using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveableObject : MonoBehaviour
{
    public GameObject selectedObject;
    public GameObject tower;
    Vector3Int cellPosition;
    public Grid grid;
    public GameObject hover;
    private int layerIgnoreRaycast;
    private int layerPlayer;

    public LayerMask raycastLayer;

    private void Start()
    {
        layerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        layerPlayer = LayerMask.NameToLayer("Player");
        Debug.Log(layerPlayer + " / " + raycastLayer.value);
    }
    void Update()
    {
        
        //Event to hide UI/object when cursor above UI
        //unity event on start drag and on end drag
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //Collider2D lookForTowers = Physics2D.OverlapPoint((mousePosition), raycastLayer);
        //Debug.Log("Look for tower" + lookForTowers);

        //return;
        //this event is active when you are pointing over the UI
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log(selectedObject);
            if (!selectedObject)
            {
                Debug.Log("No selected object");
                Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                //Debug.Log(" Target object" + targetObject);
                if (targetObject)
                {
                    selectedObject = targetObject.transform.gameObject;
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
            }
        }
        if (selectedObject)
        {
            Debug.Log("Yes selected object");
            Collider2D lookForTowers = Physics2D.OverlapPoint((mousePosition), raycastLayer);
            //Debug.Log("Look for tower" + lookForTowers);
             if (lookForTowers)
             {
                Debug.Log("There's already a tower here ");
             }
             else
             {
                cellPosition = grid.LocalToCell(mousePosition);
                hover.transform.position = grid.GetCellCenterLocal(cellPosition);
            }
            
        }  
    }

    public void SpawnTower()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject newTower = Instantiate(tower, mousePosition, Quaternion.identity);
        selectedObject = newTower;
        selectedObject.layer = layerIgnoreRaycast;
        hover.SetActive(true);
        Debug.Log("New selected object: " + selectedObject);
    }
}

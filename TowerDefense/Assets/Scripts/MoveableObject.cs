using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    public GameObject selectedObject;
    Vector3 offset;
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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //Collider2D lookForTowers = Physics2D.OverlapPoint((mousePosition), raycastLayer);
        //Debug.Log("Look for tower" + lookForTowers);

        //return;
        if (Input.GetMouseButtonUp(0))
        {
            if (!selectedObject)
            {
                Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                Debug.Log(" Target object" + targetObject);
                if (targetObject)
                {
                    selectedObject = targetObject.transform.gameObject;
                    offset = selectedObject.transform.position - mousePosition;
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
            
            Collider2D lookForTowers = Physics2D.OverlapPoint((mousePosition), raycastLayer);
            Debug.Log("Look for tower" + lookForTowers);
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
}

using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Class responsible for all the clicking in the game
/// </summary>
public class MoveableObject : MonoBehaviour
{
    [SerializeField] private GameObject towerSingle;
    [SerializeField] private GameObject towerArea;
    [SerializeField] private GameObject towerDebuff;
    [SerializeField] private Grid grid;
    [SerializeField] private LayerMask raycastLayer;
    [SerializeField] private InventoryManager inventoryManager;
    
    private Vector3Int _cellPosition;
    private GameObject _hover;
    private GameObject _range;
    private GameObject _selectedObject;
    private int _layerIgnoreRaycast;
    private int _layerPlayer;
    private int _singleTowerPrice;
    private int _areaTowerPrice;
    private int _debuffTowerPrice;


    private void Start()
    {
        _layerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        _layerPlayer = LayerMask.NameToLayer("Player");
        _singleTowerPrice = towerSingle.GetComponent<TowerBase>().GetPrice();
        _areaTowerPrice = towerArea.GetComponent<TowerBase>().GetPrice();
        _debuffTowerPrice = towerDebuff.GetComponent<TowerBase>().GetPrice();
        inventoryManager.SetUpPrices(
            _singleTowerPrice,
            _areaTowerPrice,
            _debuffTowerPrice
            );
    }
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!LevelManager.Instance.GetWaveInProgress())
        {
            //this event is active when you are pointing over the UI
            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (!_selectedObject)
                {
                    Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                    if (targetObject)
                    {
                        _selectedObject = targetObject.transform.gameObject;
                        _hover = _selectedObject.transform.GetChild(0).gameObject;
                        _selectedObject.layer = _layerIgnoreRaycast;
                        _hover.SetActive(true);
                    }
                } 
                else
                {
                    _selectedObject.transform.position = grid.GetCellCenterLocal(_cellPosition);
                    _hover.transform.position = grid.GetCellCenterLocal(_cellPosition);
                    _hover.SetActive(false);
                    _selectedObject.layer = _layerPlayer;
                    _selectedObject = null;
                    _hover = null;
                }
            }
            else if (Input.GetMouseButtonUp(1))
            {
                if (!_selectedObject)
                {
                    Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                    if (targetObject.GetComponent<TowerBase>().GetTowerUpgrade())
                    {
                        targetObject.GetComponent<TowerBase>().Upgrade();
                    }
                }
            }
        }
        
        
        if (_selectedObject)
        {
            Collider2D lookForTowers = Physics2D.OverlapPoint((mousePosition), raycastLayer);
             if (!lookForTowers)
             {
                 _cellPosition = grid.LocalToCell(mousePosition);
                 if (_hover != null) _hover.transform.position = grid.GetCellCenterLocal(_cellPosition);
             }
        }  
    }

    //Used in buttons
    public void SpawnTowerSingle()
    {
        LevelManager.Instance.SetMoney(-_singleTowerPrice);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject newTower = Instantiate(towerSingle, mousePosition, Quaternion.identity);
        _selectedObject = newTower;
        _selectedObject.layer = _layerIgnoreRaycast;
        _hover = _selectedObject.transform.GetChild(0).gameObject;
        _hover.SetActive(true);
    }

    public void SpawnTowerArea()
    {
        LevelManager.Instance.SetMoney(-_areaTowerPrice);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject newTower = Instantiate(towerArea, mousePosition, Quaternion.identity);
        _selectedObject = newTower;
        _selectedObject.layer = _layerIgnoreRaycast;
        _hover = _selectedObject.transform.GetChild(0).gameObject;
        _hover.SetActive(true);
    }

    public void SpawnTowerDebuff()
    {
        LevelManager.Instance.SetMoney(-_debuffTowerPrice);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject newTower = Instantiate(towerDebuff, mousePosition, Quaternion.identity);
        _selectedObject = newTower;
        _selectedObject.layer = _layerIgnoreRaycast;
        _hover = _selectedObject.transform.GetChild(0).gameObject;
        _hover.SetActive(true);
    }
}

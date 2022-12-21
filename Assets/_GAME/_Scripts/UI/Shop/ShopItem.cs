using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopItem : MonoBehaviour {

    [SerializeField] private UIInventory _inventoryMenu;
    [SerializeField] private Item.Type itemType;
    private                  Item _item;
    private                  InventoryManager _inventoryManager;
    private                  Color _disableColor = new Color32(152, 152, 152, 255);
    private                  Color _enableColor = Color.white;
    private                  GameObject _itemIcon, _priceBoard, _coinIcon, _info;
    private                  TMPro.TextMeshProUGUI _tooltipTxt, _priceTxt;


    // Start is called before the first frame update
    void Start() {
        _item = FindObjectOfType(typeof(Item)) as Item; 
        _inventoryManager = FindObjectOfType(typeof(InventoryManager)) as InventoryManager;

        _itemIcon = transform.GetChild(0).gameObject;   
        _priceBoard = transform.GetChild(1).gameObject;
        _info = transform.GetChild(2).gameObject;

        _coinIcon = _priceBoard.transform.GetChild(1).gameObject;
        _priceTxt = _priceBoard.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        _tooltipTxt = _info.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        
        _itemIcon.GetComponent<Image>().sprite = _item.GetSprite(itemType);
        _tooltipTxt.text = itemType.ToString();
        _priceTxt.text = _item.GetPrice(itemType).ToString();
    }


    // Update is called once per frame
    void Update() {
        DisableItem(IsCanBuy());
    }


    void DisableItem(bool isCanBuy) {
        Color color = isCanBuy ? _enableColor : _disableColor;

        gameObject.GetComponent<ClickyButton>().enabled = isCanBuy;
        gameObject.GetComponent<Button>().enabled = isCanBuy;
        gameObject.GetComponent<CustomEvent>().enabled = isCanBuy;

        gameObject.GetComponent<Image>().color = color;
        _itemIcon.GetComponent<Image>().color = color;
        _priceBoard.GetComponent<Image>().color = color;
        _coinIcon.GetComponent<Image>().color = color;
        _priceTxt.color = color;
    }


    bool IsCanBuy() {
        return PlayerController.budget >=  _item.GetPrice(itemType);
    }


    public void Buy() {
        if (IsCanBuy()) {
            Item tempItem = new Item {
                            itemType = itemType,
                            amount = 1
                        };

            PlayerController.budget -= _item.GetPrice(itemType);
            InventoryManager.instance.AddItem(tempItem);

            // refesh inventory
            _inventoryMenu.SetInventory(_inventoryManager);
        } 
    }
}

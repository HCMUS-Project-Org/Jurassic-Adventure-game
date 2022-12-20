using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopItem : MonoBehaviour {

    [SerializeField] private Item.Type itemType;
    private                  Item _item;
    private                  GameObject _itemIcon, _priceBoard, _coinIcon, _info;
    private                  TMPro.TextMeshProUGUI _tooltipTxt, _priceTxt;
    private                  Color _disableColor = new Color32(152, 152, 152, 255);
    private                  Color _enableColor = Color.white;


    // Start is called before the first frame update
    void Start() {
        _item = FindObjectOfType(typeof(Item)) as Item; 

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
        if (isCanBuy) {
            gameObject.GetComponent<ClickyButton>().enabled = true;
            gameObject.GetComponent<CustomEvent>().enabled = true;
            gameObject.GetComponent<Button>().enabled = true;

            gameObject.GetComponent<Image>().color = _enableColor;
            _itemIcon.GetComponent<Image>().color = _enableColor;
            _priceBoard.GetComponent<Image>().color = _enableColor;
            _coinIcon.GetComponent<Image>().color = _enableColor;
            _priceTxt.color = _enableColor;
        } 
        else {
            gameObject.GetComponent<ClickyButton>().enabled = false;
            gameObject.GetComponent<CustomEvent>().enabled = false;
            gameObject.GetComponent<Button>().enabled = false;

            gameObject.GetComponent<Image>().color = _disableColor;
            _itemIcon.GetComponent<Image>().color = _disableColor;
            _priceBoard.GetComponent<Image>().color = _disableColor;
            _coinIcon.GetComponent<Image>().color = _disableColor;
            _priceTxt.color = _disableColor;
        }
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
        } 
    }
}

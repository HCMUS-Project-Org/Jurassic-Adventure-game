using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _tooltip, _price;
    private                  GameObject _itemIcon, _priceBoard, _coinIcon;
    
    private Color _disableColor = new Color32(152, 152, 152, 255);
    private Color _enableColor = Color.white;

    public string itemName;
    public string itemPrice;
    public string itemID;




    void Start() {
        _itemIcon = transform.GetChild(0).gameObject;   
        _priceBoard = transform.GetChild(1).gameObject;
        _coinIcon = _priceBoard.transform.GetChild(1).gameObject;
        
        _tooltip.text = itemName != null ? itemName : "Null";
        _price.text = itemPrice; 
    }


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
            _price.color = _enableColor;
        } 
        else {
            gameObject.GetComponent<ClickyButton>().enabled = false;
            gameObject.GetComponent<CustomEvent>().enabled = false;
            gameObject.GetComponent<Button>().enabled = false;

            gameObject.GetComponent<Image>().color = _disableColor;
            _itemIcon.GetComponent<Image>().color = _disableColor;
            _priceBoard.GetComponent<Image>().color = _disableColor;
            _coinIcon.GetComponent<Image>().color = _disableColor;
            _price.color = _disableColor;
        }
    }


    bool IsCanBuy() {
        return PlayerController.budget >= int.Parse(itemPrice);
    }


    public void Buy() {
        PlayerController.budget -= int.Parse(itemPrice);
        InventoryManager.instance.AddItem(this);
    }
}

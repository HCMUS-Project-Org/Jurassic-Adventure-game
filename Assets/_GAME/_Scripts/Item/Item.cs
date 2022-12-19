using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour {
    public enum ItemType {
        Health,
        Mana,
        Poison,
        Medkit,
        Coin,
    }

    [SerializeField] private GameObject _itemPropertyPanel;
    private                  GameObject _itemIcon, _priceBoard, _coinIcon, _info;

    private                  TMPro.TextMeshProUGUI _tooltipTxt, _priceTxt;

    private                  Color _disableColor = new Color32(152, 152, 152, 255);
    private                  Color _enableColor = Color.white;

    public ItemType itemType;
    public int amount;


    void Start() {
        _itemIcon = transform.GetChild(0).gameObject;   
        _priceBoard = transform.GetChild(1).gameObject;
        _info = transform.GetChild(2).gameObject;

        _coinIcon = _priceBoard.transform.GetChild(1).gameObject;
        _priceTxt = _priceBoard.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        _tooltipTxt = _info.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        
        _itemIcon.GetComponent<Image>().sprite = this.GetSprite(this.itemType);
        _tooltipTxt.text = this.itemType.ToString();
        _priceTxt.text = this.GetPrice(this.itemType).ToString();
    }


    void Update() {
        DisableItem(IsCanBuy());
    }


    public Sprite GetSprite(ItemType itemType) {
        switch (itemType) {
            case ItemType.Health:
                return ItemAssets.instance.healthSprite;
            case ItemType.Mana:
                return ItemAssets.instance.manaSprite;
            case ItemType.Poison:
                return ItemAssets.instance.poisonSprite;
            case ItemType.Medkit:
                return ItemAssets.instance.medkitSprite;
            case ItemType.Coin:
                return ItemAssets.instance.coinSprite;
            default:
                return null;
        }
    }


    public int GetPrice(ItemType itemType) {
        switch (itemType) {
            case ItemType.Health:
                return 12;
            case ItemType.Mana:
                return 15;
            case ItemType.Poison:
                return 20;
            case ItemType.Medkit:
                return 32;
            case ItemType.Coin:
                return 16;
            default:
                return 0;
        }
    }


    public string GetDescription(ItemType itemType) {
        switch (itemType) {
            case ItemType.Health:
                return "This is health";
            case ItemType.Mana:
                return "This is mana";
            case ItemType.Poison:
                return "This is poison";
            case ItemType.Medkit:
                return "This is Medkit";
            case ItemType.Coin:
                return "This is coin";
            default:
                return null;
        }
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


    public void SelectItem() {
        ChangePropertyPanelDetail();
    }


    void ChangePropertyPanelDetail() {
        TMPro.TextMeshProUGUI itemName, description;
        Image itemImage;

        itemName = _itemPropertyPanel.transform.Find("ItemName").GetComponent<TMPro.TextMeshProUGUI>();
        description = _itemPropertyPanel.transform.Find("Description").GetComponent<TMPro.TextMeshProUGUI>();
        itemImage = _itemPropertyPanel.transform.Find("ItemImg").GetComponent<Image>();

        itemName.text = this.itemType.ToString();
        description.text = this.GetDescription(this.itemType);
        itemImage.sprite = this.GetSprite(this.itemType);
    }


    bool IsCanBuy() {
        return PlayerController.budget >=  this.GetPrice(this.itemType);
    }


    public void Buy() {
        if (IsCanBuy()) {
            PlayerController.budget -= this.GetPrice(this.itemType);
            InventoryManager.instance.AddItem(this);
        } else {
            Debug.Log("Not enough money");
        }
    }
}

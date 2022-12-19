using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour {
    
    [SerializeField] private ItemAssets _itemAssets;
    [SerializeField] private GameObject _itemPropertyPanel;
    [SerializeField] private TMPro.TextMeshProUGUI _tooltip, _price;

    public enum ItemType {
        Health,
        Mana,
        Poison,
        Medkit,
        Coin,
    }

    public ItemType itemType;
    public int price;
    public int amount;

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
        return PlayerController.budget >= this.price;
    }


    public void Buy() {
        if (IsCanBuy()) {
            PlayerController.budget -= this.price;
            InventoryManager.instance.AddItem(this);
        } else {
            Debug.Log("Not enough money");
        }
    }
}

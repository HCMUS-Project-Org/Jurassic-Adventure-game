using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour {
    public enum Type {
        Health,
        Mana,
        Poison,
        Medkit,
        Coin,
    }

    [SerializeField] private GameObject _itemPropertyPanel;

    public Type itemType;
    public int amount;


    public Sprite GetSprite(Type itemType) {
        switch (itemType) {
            case Type.Health:
                return ItemAssets.instance.healthSprite;
            case Type.Mana:
                return ItemAssets.instance.manaSprite;
            case Type.Poison:
                return ItemAssets.instance.poisonSprite;
            case Type.Medkit:
                return ItemAssets.instance.medkitSprite;
            case Type.Coin:
                return ItemAssets.instance.coinSprite;
            default:
                return null;
        }
    }


    public int GetPrice(Type itemType) {
        switch (itemType) {
            case Type.Health:
                return 12;
            case Type.Mana:
                return 15;
            case Type.Poison:
                return 20;
            case Type.Medkit:
                return 32;
            case Type.Coin:
                return 16;
            default:
                return 0;
        }
    }


    public string GetDescription(Type itemType) {
        switch (itemType) {
            case Type.Health:
                return "This is health";
            case Type.Mana:
                return "This is mana";
            case Type.Poison:
                return "This is poison";
            case Type.Medkit:
                return "This is Medkit";
            case Type.Coin:
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
}

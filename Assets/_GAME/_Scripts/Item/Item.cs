using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Item : MonoBehaviour
{
    public enum Type
    {
        Health,
        Medkit,
        Mana,
        Experience,
        Life
    }

    [SerializeField] private GameObject _itemPropertyPanel;

    public Type itemType;
    public int  amount;


    public Sprite GetSprite(Type itemType)
    {
        switch (itemType)
        {
            case Type.Health:
                return ItemAssets.instance.healthSprite;
            case Type.Mana:
                return ItemAssets.instance.manaSprite;
            case Type.Medkit:
                return ItemAssets.instance.medkitSprite;
            case Type.Experience:
                return ItemAssets.instance.experienceSprite;
            case Type.Life:
                return ItemAssets.instance.lifeSprite;
            default:
                return null;
        }
    }


    public int GetPrice(Type itemType)
    {
        switch (itemType)
        {
            case Type.Health:
                return 12;
            case Type.Mana:
                return 15;
            case Type.Medkit:
                return 32;
            case Type.Experience:
                return 16;
            case Type.Life:
                return 50;
            default:
                return 0;
        }
    }
    
    public string GetDescription(Type itemType) => itemType switch
    {
        Type.Health     => "Restores 4 HP.",
        Type.Medkit     => "Regenerates 1 HP every 2 second for 12 seconds (6 HP in total).",
        Type.Mana       => "Restores 4 Mana.",
        Type.Experience => "Get 10 EXP.",
        Type.Life       => "Get 1 Life.",
    };

    public void SelectItem()
    {
        ChangePropertyPanelDetail();
    }


    void ChangePropertyPanelDetail()
    {
        TMPro.TextMeshProUGUI itemName, description;
        Image                 itemImage;

        itemName    = _itemPropertyPanel.transform.Find("ItemName").GetComponent<TMPro.TextMeshProUGUI>();
        description = _itemPropertyPanel.transform.Find("Description").GetComponent<TMPro.TextMeshProUGUI>();
        itemImage   = _itemPropertyPanel.transform.Find("ItemImg").GetComponent<Image>();

        itemName.text    = this.itemType.ToString();
        description.text = this.GetDescription(this.itemType);
        itemImage.sprite = this.GetSprite(this.itemType);
    }

    private PlayerHealth _playerHealth;
    private PlayerHealth PlayerHealth => _playerHealth ??= FindObjectOfType<PlayerHealth>();

    public void Use()
    {
        switch (itemType)
        {
            case Type.Health:
                PlayerHealth.Heal(4);
                break;
            case Type.Medkit:
                StartCoroutine(PlayerHealth.StartRegen());
                break;
            case Type.Mana:
                PlayerHealth.RegenMana();
                break;
            case Type.Experience:
                break;
        }

        // remove used item
        InventoryManager.instance.RemoveItem(this);
    }
}
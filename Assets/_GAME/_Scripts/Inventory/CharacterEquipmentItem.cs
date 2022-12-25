using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipmentItem : MonoBehaviour
{
     private List<Item> _equipmentList;

    public static CharacterEquipmentItem instance;

    public CharacterEquipmentItem() {
        _equipmentList = new List<Item>();

        AddEquipmentItem(new Item {
            itemType = Item.Type.Mana,
            amount = 1
        });
        AddEquipmentItem(new Item {
            itemType = Item.Type.Health,
            amount = 1
        });
        
         AddEquipmentItem(new Item {
            itemType = Item.Type.Poison,
            amount = 1
        });
    }

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void AddEquipmentItem(Item addItem) {
        for (int i = 0; i < _equipmentList.Count; i++) {
            if (_equipmentList[i].itemType == addItem.itemType) {
                Item tempItem = new Item {
                    itemType = addItem.itemType,
                    amount = _equipmentList[i].amount + addItem.amount
                };

                _equipmentList[i] = tempItem;

                return;
            }
        }

        _equipmentList.Add(addItem);
    }
}

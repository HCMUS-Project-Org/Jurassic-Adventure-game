using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipmentItem : MonoBehaviour
{
    void Update() {
        string gameObjectName = gameObject.name;
        int slotIndex = int.Parse(gameObjectName.Substring(gameObjectName.Length - 1));

        if (gameObject.transform.childCount > 0) {
            Item _itemInSlot = gameObject.transform.GetChild(0).GetComponent<Item>();
            _itemInSlot.amount = GetItemAmount(_itemInSlot);
    
            if (_itemInSlot != null) 
                EquipmentManager.instance.ChangeSlotEquipment(slotIndex, _itemInSlot);
        }
        else {
            EquipmentManager.instance.ChangeSlotEquipment(slotIndex, null);
        } 

//        Debug.Log("slot:" + slotIndex + " item:" + EquipmentManager.instance.GetEquipmentList()[slotIndex]);
    }


    int GetItemAmount(Item item) {
        List<Item> itemList = InventoryManager.instance.GetItemList();

        for (int i = 0; i < itemList.Count; i++) {
            if (itemList[i].itemType == item.itemType) {
                return itemList[i].amount;
            }
        }

        return 1;
    }
}

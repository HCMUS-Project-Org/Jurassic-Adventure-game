using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    private Item[] _equipmentList;

    public static EquipmentManager instance;

    public EquipmentManager() {
        _equipmentList = new Item[3];

        _equipmentList[0] = null;
        _equipmentList[1] = null;
        _equipmentList[2] = null;
    }


    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }


    void Update() {
        for (int i = 0; i < _equipmentList.Length; i++) {
            if (_equipmentList[i] != null) {
                if (!checkItemExistInInventory(_equipmentList[i])) {
                    _equipmentList[i] = null;
                }
                else {
                    _equipmentList[i].amount = updateEquipmentItemInventoryAmount(_equipmentList[i]);

                    GameObject quickItemSlot = GameObject.Find("QuickItemSlot " + i.ToString());
                    GameObject itemInSlot = quickItemSlot.transform.GetChild(0).gameObject;
                    GameObject amountBadge = itemInSlot.transform.Find("amountBadge").gameObject;


                    if (_equipmentList[i].amount > 1) {     
                        amountBadge.SetActive(true); 

                        TMPro.TextMeshProUGUI amountText = amountBadge.transform.Find("amountTxt").GetComponent<TMPro.TextMeshProUGUI>();
                        amountText.text = _equipmentList[i].amount.ToString();
                    }
                    else {
                        amountBadge.SetActive(false);
                    }

                    print( _equipmentList[i].itemType + ": " + _equipmentList[i].amount + " - crr: " +updateEquipmentItemInventoryAmount(_equipmentList[i]));
                }
            }
        }
    }

    bool checkItemExistInInventory(Item item) {
        List<Item> inventoryItemList = InventoryManager.instance.GetItemList();

        foreach (Item inventoryItem in inventoryItemList) {
            if (inventoryItem.itemType == item.itemType) {
                return true;
            }
        }

        return false;
    }

    int updateEquipmentItemInventoryAmount(Item item) {
        List<Item> inventoryItemList = InventoryManager.instance.GetItemList();

        foreach (Item inventoryItem in inventoryItemList) {
            if (inventoryItem.itemType == item.itemType) {
                return inventoryItem.amount;
            }
        }

        return item.amount;
    }

    public void ChangeSlotEquipment(int slotIdx, Item addItem) {
        _equipmentList[slotIdx] = addItem;
    }


    public Item[] GetEquipmentList() {
        return _equipmentList;
    }
}

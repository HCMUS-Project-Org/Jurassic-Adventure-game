using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickItemController : MonoBehaviour {
    [SerializeField] private UIInventory _uiInventory;

    void Update() {

        Item[] equipmentItem =  EquipmentManager.instance.GetEquipmentList();

        for (int i = 0; i < equipmentItem.Length; i++) {
            GameObject quickItemSlot = GameObject.Find("QuickItemSlot " + i.ToString());

            if (equipmentItem[i] != null) {
                if (quickItemSlot.transform.childCount == 0) {
                    _uiInventory.InstantiateItem(equipmentItem[i], quickItemSlot);

                     Item itemInSlot = quickItemSlot.transform.GetChild(0).GetComponent<Item>();
                     itemInSlot.GetComponent<DragAndDrop>().enabled = false;
                }
                else {
                    Item itemInSlot = quickItemSlot.transform.GetChild(0).GetComponent<Item>();

                    if (itemInSlot.itemType != equipmentItem[i].itemType) {
                        Destroy(itemInSlot.gameObject);

                        _uiInventory.InstantiateItem(equipmentItem[i], quickItemSlot);
                    }
                }
            }
            else {
                if (quickItemSlot.transform.childCount > 0) {
                    Item itemInSlot = quickItemSlot.transform.GetChild(0).GetComponent<Item>();

                    Destroy(itemInSlot.gameObject);
                }
            }
        }
    }
}

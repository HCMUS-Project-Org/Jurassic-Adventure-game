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

    
    public void ChangeSlotEquipment(int slotIdx, Item addItem) {
        _equipmentList[slotIdx] = addItem;
    }


    public Item[] GetEquipmentList() {
        return _equipmentList;
    }
}

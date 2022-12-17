using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public struct InventoryItem {
        public Item item { get; set; }
        public int quantity { get; set; }
    }

    private List<InventoryItem> _inventoryItem = new List<InventoryItem>();
    public static InventoryManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {

        
    }

    public void AddItem(Item item) {
        bool isExist = false;

        // Add item to inventory
        for (int i = 0; i < _inventoryItem.Count; i++) {
            if (_inventoryItem[i].item.itemID == item.itemID) {
                InventoryItem tempItem = new InventoryItem();

                tempItem.item = _inventoryItem[i].item;
                tempItem.quantity = _inventoryItem[i].quantity + 1;

                _inventoryItem[i] = tempItem;

                isExist = true;

                LogInventory();
                return;
            }
        }

        if (!isExist) {
            InventoryItem newItem = new InventoryItem();
            
            newItem.item = item;
            newItem.quantity = 1;
            
            _inventoryItem.Add(newItem);
        }

        LogInventory();
    }

    void LogInventory() {
        Debug.Log("============================");

        for (int i = 0; i < _inventoryItem.Count; i++) {
            Debug.Log(_inventoryItem[i].item.itemName + " " + _inventoryItem[i].quantity);
        }
    }
}

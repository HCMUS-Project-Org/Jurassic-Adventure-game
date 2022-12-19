using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    
    private List<Item> _itemList;

    public static InventoryManager instance;

    public InventoryManager() {
        _itemList = new List<Item>();

         AddItem(new Item {
            itemType = Item.ItemType.Mana,
            amount = 1
        });
        AddItem(new Item {
            itemType = Item.ItemType.Health,
            amount = 1
        });
        
         AddItem(new Item {
            itemType = Item.ItemType.Poison,
            amount = 1
        });
          AddItem(new Item {
            itemType = Item.ItemType.Medkit,
            amount = 3
        });
          AddItem(new Item {
            itemType = Item.ItemType.Coin,
            amount = 2
        });
          AddItem(new Item {
            itemType = Item.ItemType.Health,
            amount = 1
        });
              AddItem(new Item {
            itemType = Item.ItemType.Health,
            amount = 3
        });
           AddItem(new Item {
            itemType = Item.ItemType.Medkit,
            amount = 2
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


    public void AddItem(Item addItem) {
        for (int i = 0; i < _itemList.Count; i++) {
            if (_itemList[i].itemType == addItem.itemType) {
                Item tempItem = new Item {
                    itemType = addItem.itemType,
                    amount = _itemList[i].amount + addItem.amount
                };

                _itemList[i] = tempItem;

                return;
            }
        }

        _itemList.Add(addItem);
    }


    public void RemoveItem(Item item) {
        _itemList.Remove(item);
    }


    public List<Item> GetItemList() {
        return _itemList;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<Item> _itemList;

    public static InventoryManager instance;

    public InventoryManager()
    {
        _itemList = new List<Item>();

       
        // AddItem(new Item
        // {
        //     itemType = Item.Type.Health,
        //     amount   = 1
        // });
        //  AddItem(new Item
        // {
        //     itemType = Item.Type.Mana,
        //     amount   = 1
        // });

        // AddItem(new Item
        // {
        //     itemType = Item.Type.Experience,
        //     amount   = 1
        // });
        // AddItem(new Item
        // {
        //     itemType = Item.Type.Medkit,
        //     amount   = 3
        // });
        // AddItem(new Item
        // {
        //     itemType = Item.Type.Health,
        //     amount   = 1
        // });
        // AddItem(new Item
        // {
        //     itemType = Item.Type.Health,
        //     amount   = 3
        // });
        // AddItem(new Item
        // {
        //     itemType = Item.Type.Medkit,
        //     amount   = 2
        // });
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddItem(Item addItem)
    {
        for (int i = 0; i < _itemList.Count; i++)
        {
            if (_itemList[i].itemType == addItem.itemType)
            {
                Item tempItem = new Item
                {
                    itemType = addItem.itemType,
                    amount   = _itemList[i].amount + addItem.amount
                };

                _itemList[i] = tempItem;

                return;
            }
        }

        _itemList.Add(addItem);

        print("-------------------------------");
        foreach(Item item in _itemList)
        {
            Debug.Log(item.itemType + " - " + item.amount);
        }
    }


    public void RemoveItem(Item removeItem)
    {

     print("-------------------------");
        for (int i = 0; i < _itemList.Count; i++)
        {
            if (_itemList[i].itemType == removeItem.itemType)
            {
                if (_itemList[i].amount <= 1)
                {
                    _itemList.RemoveAt(i);
                    print("======== Remove");
                    break;
                } 
                else 
                {
                    Item tempItem = new Item
                    {
                        itemType = removeItem.itemType,
                        amount   = _itemList[i].amount - 1
                    };

                    _itemList[i] = tempItem;
                }
            }
        }

   
        print("- RemoveItem: " + removeItem.itemType);
        foreach (Item item in _itemList)
        {
            print(item.itemType + " " + item.itemType + " - " + item.amount);
        }
    }


    public List<Item> GetItemList()
    {
        return _itemList;
    }
}
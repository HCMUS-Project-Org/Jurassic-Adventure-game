using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIInventory : MonoBehaviour {
    [SerializeField] private List<GameObject> _itemSlotList;
    [SerializeField] private GameObject _inventoryItem;
    private                  InventoryManager _inventoryManager;
    
    
    public void SetInventory(InventoryManager inventoryManager) {
        _inventoryManager = inventoryManager;
        RefreshInventoryItems();
    }


    void ClearInventory() {
        // remove all items from inventory
        foreach(GameObject item in GameObject.FindGameObjectsWithTag("Item")) {
            if(item.name == "InventoryItem(Clone)") {
                Destroy(item);
            }
        }
    }


    public void RefreshInventoryItems() {
        ClearInventory();

        for (int i = 0; i < _itemSlotList.Count; i++) {     
            
            GameObject currentSlot = _itemSlotList[i].gameObject; 

            // create item in slot
            if (i < _inventoryManager.GetItemList().Count) {
                Item item = _inventoryManager.GetItemList()[i];
                RectTransform itemImageRectTransform = Instantiate(_inventoryItem, GetComponent<RectTransform>()).GetComponent<RectTransform>();

                GameObject amountBadge = itemImageRectTransform.transform.Find("amountBadge").gameObject;

                // add item to slot
                itemImageRectTransform.SetParent(currentSlot.transform);
                itemImageRectTransform.gameObject.SetActive(true);

                // set item properties
                itemImageRectTransform.gameObject.GetComponent<Item>().itemType = item.itemType;
                itemImageRectTransform.gameObject.GetComponent<Image>().sprite =  item.GetSprite(item.itemType);

                // show amount badge 
                if (item.amount > 1) {     
                    amountBadge.SetActive(true); 

                    TMPro.TextMeshProUGUI amountText = amountBadge.transform.Find("amountTxt").GetComponent<TMPro.TextMeshProUGUI>();
                    amountText.text = item.amount.ToString();
                }
                else {
                    amountBadge.SetActive(false);
                }
            }
        }
    }
}

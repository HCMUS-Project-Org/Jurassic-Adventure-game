using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour {

    [SerializeField] private List<GameObject> _itemSlotList;
    [SerializeField] private Sprite _activeSlotSprite;
    private                  InventoryManager _inventoryManager;
    private                  Image _itemImage;
    
    
    void Awake() {
        _itemImage = transform.Find("ItemImg").GetComponent<Image>();
    }


    public void SetInventory(InventoryManager inventoryManager) {
        _inventoryManager = inventoryManager;
        RefreshInventoryItems();
    }


    private void RefreshInventoryItems() {
        for (int i = 0; i < _itemSlotList.Count; i++) {     
            Vector2 slotAnchorPosition = _itemSlotList[i].GetComponent<RectTransform>().anchoredPosition;
            
            GameObject currentSlot = _itemSlotList[i].gameObject; 

            if (i < _inventoryManager.GetItemList().Count) {
                RectTransform itemImageRectTransform = Instantiate(_itemImage, GetComponent<RectTransform>()).GetComponent<RectTransform>();

                GameObject amountBadge = itemImageRectTransform.transform.Find("amountBadge").gameObject;

                Item item = _inventoryManager.GetItemList()[i];

                // add item to slot
                itemImageRectTransform.gameObject.SetActive(true);

                // set item properties
                itemImageRectTransform.gameObject.GetComponent<Item>().itemType = item.itemType;

                // change slot sprite
                currentSlot.GetComponent<Image>().sprite = _activeSlotSprite;

                // show item image
                itemImageRectTransform.anchoredPosition = slotAnchorPosition;

                itemImageRectTransform.gameObject.GetComponent<Image>().sprite =  item.GetSprite(item.itemType);

                // // show amount badge 
                if (item.amount > 1) {     
                    amountBadge.SetActive(true); 

                    TMPro.TextMeshProUGUI amountText = amountBadge.transform.Find("amountTxt").GetComponent<TMPro.TextMeshProUGUI>();
                    amountText.text = item.amount.ToString();
                }
                else {
                    amountBadge.SetActive(false);
                }
            }
            else {
                // disable slot
                currentSlot.GetComponent<ItemSlot>().enabled = false;
            }
        }
    }
}

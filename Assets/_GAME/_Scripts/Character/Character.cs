using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{    


    public enum Type {
        Ninja,
        Knight
    }
    // public Sprite GetSprite(CharacterType characterType) {
    //     switch (itemType) {
    //         case ItemType.Health:
    //             return ItemAssets.instance.healthSprite;
    //         case ItemType.Mana:
    //             return ItemAssets.instance.manaSprite;
    //         case ItemType.Poison:
    //             return ItemAssets.instance.poisonSprite;
    //         case ItemType.Medkit:
    //             return ItemAssets.instance.medkitSprite;
    //         case ItemType.Coin:
    //             return ItemAssets.instance.coinSprite;
    //         default:
    //             return null;
    //     }
    // }

    // public int GetPrice(ItemType itemType) {
    //     switch (itemType) {
    //         case ItemType.Health:
    //             return 12;
    //         case ItemType.Mana:
    //             return 15;
    //         case ItemType.Poison:
    //             return 20;
    //         case ItemType.Medkit:
    //             return 32;
    //         case ItemType.Coin:
    //             return 16;
    //         default:
    //             return 0;
    //     }
    // }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour 
{
    public static ItemAssets instance { get; private set; }

    public Sprite healthSprite;
    public Sprite manaSprite;
    public Sprite experienceSprite;
    public Sprite medkitSprite;
    public Sprite lifeSprite;


    private void Awake() {
        instance = this;
    }
}

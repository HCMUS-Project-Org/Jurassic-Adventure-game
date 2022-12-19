using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAssets : MonoBehaviour
{
    public static CharacterAssets instance { get; private set; }

    public RuntimeAnimatorController  _ninjaController;
    public RuntimeAnimatorController  _knightController;


    private void Awake() {
        instance = this;
    }
}

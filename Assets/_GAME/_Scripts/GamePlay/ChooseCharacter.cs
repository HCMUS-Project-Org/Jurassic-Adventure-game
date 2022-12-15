using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseCharacter : MonoBehaviour {

    public enum Character {
        Ninja,
        Knight
    }

    [SerializeField] private GameObject _ninja, _knight;
    [SerializeField] private GameObject _knightSelectedArrow, _ninjaSelectedArrow;
    private                  TMPro.TextMeshProUGUI _characterName;

    public static int character = 0;


    void Start() {
        _characterName = GameObject.Find("CharacterName").GetComponent<TextMeshProUGUI>();  
    }


    public void PickCharacter(int characterIdx) {
        // 1: knight // 2: ninja
        if (characterIdx == 1) {
            // knight
            _knight.SetActive(true);
            _ninja.SetActive(false);
            _ninjaSelectedArrow.SetActive(false);
            _knightSelectedArrow.SetActive(true);
            
            _characterName.text = "Knight";
            character = 1;
        }
        else if (characterIdx == 0) {
            // ninja
            _knight.SetActive(false);
            _ninja.SetActive(true);
            _knightSelectedArrow.SetActive(false);
            _ninjaSelectedArrow.SetActive(true);
            
            _characterName.text = "Ninja";            
            character = 0;
        }
    }
}

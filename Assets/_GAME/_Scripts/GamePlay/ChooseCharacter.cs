using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseCharacter : MonoBehaviour {

    // public enum Character {
    //     Ninja,
    //     Knight
    // }

    [SerializeField] private GameObject _ninja, _knight;
    [SerializeField] private GameObject _knightSelectedArrow, _ninjaSelectedArrow;
    private                  TMPro.TextMeshProUGUI _characterName;

    public static Character.Type characterType;


    void Awake() {
        _characterName = GameObject.Find("CharacterName").GetComponent<TextMeshProUGUI>();  
    }

    

    public void PickCharacter(int pickCharacterType) {
        // 1: knight // 2: ninja
        if (pickCharacterType == 1) {
            // knight
            _knight.SetActive(true);
            _ninja.SetActive(false);
            _ninjaSelectedArrow.SetActive(false);
            _knightSelectedArrow.SetActive(true);
            
            _characterName.text = Character.Type.Knight.ToString();
            characterType = Character.Type.Knight;
        }
        else if (pickCharacterType == 2) {
            // ninja
            _knight.SetActive(false);
            _ninja.SetActive(true);
            _knightSelectedArrow.SetActive(false);
            _ninjaSelectedArrow.SetActive(true);
            
            _characterName.text = Character.Type.Ninja.ToString();            
            characterType = Character.Type.Ninja;
        }
    }
}

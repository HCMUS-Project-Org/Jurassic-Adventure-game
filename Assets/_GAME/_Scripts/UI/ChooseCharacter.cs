using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseCharacter : MonoBehaviour
{
    [SerializeField] GameObject Ninja, Knight;
    [SerializeField] GameObject KnightSelectedArrow, NinjaSelectedArrow;
    private TMPro.TextMeshProUGUI characterName;

    public static int Character = 0;

    void Start() {
        characterName = GameObject.Find("CharacterName").GetComponent<TextMeshProUGUI>();    
    }

    public void PickCharacter(int characterIdx) {
        // 1: knight // 2: ninja
        if (characterIdx == 1) {
            // knight
            Knight.SetActive(true);
            Ninja.SetActive(false);
            NinjaSelectedArrow.SetActive(false);
            KnightSelectedArrow.SetActive(true);
            
            characterName.text = "Knight";
            Character = 1;
        }
        else if (characterIdx == 0) {
            // ninja
            Knight.SetActive(false);
            Ninja.SetActive(true);
            KnightSelectedArrow.SetActive(false);
            NinjaSelectedArrow.SetActive(true);
            
            characterName.text = "Ninja";            
            Character = 0;
        }
    }
}

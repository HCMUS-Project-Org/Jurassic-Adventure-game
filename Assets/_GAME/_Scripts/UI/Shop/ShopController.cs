using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour {

    [SerializeField] private TMPro.TextMeshProUGUI _playerBuget;
    

    void Update() {
        _playerBuget.text = PlayerController.budget.ToString();
    }
}

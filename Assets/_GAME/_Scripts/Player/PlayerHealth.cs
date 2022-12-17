using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] private HealthBar _healthBar;
    private Animator _animator;
    private TMPro.TextMeshProUGUI _healthShow; 

    public int maxHealth = 100;
    public int currentHealth;

    public int maxMana = 10;
    public int currentMana;
    

    void Start() {
        _animator = GetComponent<PlayerController>().animator;
        _healthShow = GameObject.Find("PropertyText").GetComponent<TextMeshProUGUI>();    
     
        currentHealth = maxHealth;
        _healthShow.text = "Health: " + currentHealth;
    }


    public void ChangeHealth(int amount) {
        if (amount < 0) {
            _animator.SetTrigger("Hurt");
        }

        // set value
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        _healthBar.instance.SetHealthValue(currentHealth / (float)maxHealth);
        _healthShow.text = "Health: " + currentHealth;

        Debug.Log("Player health:" + currentHealth + "/" + maxHealth);
    }

    public void ChangeMana(int amount) {
        // set value
        currentMana = Mathf.Clamp(currentMana + amount, 0, maxMana);
        _healthBar.instance.SetManaValue(currentMana / (float)maxMana);

        Debug.Log("Player Mana:" + currentMana + "/" + maxMana);
    }
}

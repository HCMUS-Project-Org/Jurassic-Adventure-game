using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour {

    private Animator _animator;
    private TMPro.TextMeshProUGUI _healthShow; 

    public int maxHealth = 100;
    public int currentHealth;
    

    void Start() {
        _animator = GetComponent<PlayerController>().animator;
        _healthShow = GameObject.Find("PropertyText").GetComponent<TextMeshProUGUI>();    
     
        currentHealth = maxHealth;
        _healthShow.text = "Health: " + currentHealth;
    }


    public void ChangeHealth(int amount) {
        if (amount < 0) {
            _animator.SetTrigger("Hurt");
            // PlaySound(triggerClip);

            // if (isInvincible)
            //     return;

            // isInvincible = true;
            // invincibleTimer = timeInvincible;
        }

        // set value
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        HealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        _healthShow.text = "Health: " + currentHealth;

        Debug.Log("Player health:" + currentHealth + "/" + maxHealth);
    }
}

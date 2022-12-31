using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] private EnemyController _enemyController;
    private                  Animator _animator;

    public HealthBar healthBar;
    
    public int maxHealth;
    public int currentHealth;


    void Start() {
        // _animator = GetComponent<EnemyController>().animator;     
        currentHealth = maxHealth;

        healthBar.Show(false);
    }


    public void ChangeHealth(int amount) {
        // if (amount < 0) {
        //     _animator.SetTrigger("Hurt");
        // }

        // set value
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        healthBar.Show(true);
        healthBar.instance.SetHealthValue(currentHealth / (float)maxHealth);
        
        if (currentHealth <= 0) {
            _enemyController.Killed();
        }

        Debug.Log("Enemy health:" + currentHealth + "/" + maxHealth);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private HealthBar _healthBar;
    private                  Animator _animator;

    public int maxHealth;
    public int currentHealth;

    void Start() {
        _animator = GetComponent<EnemyController>().animator;     
        currentHealth = maxHealth;
    }


    public void ChangeHealth(int amount) {
        if (amount < 0) {
            _animator.SetTrigger("Hurt");
        }

        // set value
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        _healthBar.instance.SetHealthValue(currentHealth / (float)maxHealth);
        
        if (currentHealth <= 0) {
            _enemyController.Killed();
        }

        Debug.Log("Enemy health:" + currentHealth + "/" + maxHealth);
    }
}

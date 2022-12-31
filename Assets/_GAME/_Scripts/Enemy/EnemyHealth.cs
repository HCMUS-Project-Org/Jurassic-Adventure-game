using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private Animator        _animator;

    public HealthBar healthBar;

    public                  int maxHealth;
    public                  int currentHealth;
    private static readonly int Hit = Animator.StringToHash("Hit");


    void Start()
    {  
        currentHealth = maxHealth;

        healthBar.Show(false);
    }

    public void GetDamage(int damage)
    {
        currentHealth -= damage;
        _animator.SetTrigger(Hit);

        healthBar.Show(true);
        healthBar.instance.SetHealthValue(currentHealth / (float)maxHealth);

        if (currentHealth == 0)
            Destroy(gameObject, .25f);
    }
}
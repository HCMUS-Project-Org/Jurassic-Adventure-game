using System;
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

    public int maxHealth => _enemyController.enemy switch
    {
        Enemy.Bunny => 5,
        Enemy.Ghost => 3,
    };
    
    private                  int currentHealth;
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
        {
            _enemyController.Died();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var colliderGameObject = col.gameObject;
        
        if (colliderGameObject.CompareTag("DealDamage"))
        {
            GetDamage(1);
            if (colliderGameObject.name.StartsWith("Projectile"))
            {
                Destroy(colliderGameObject);
            }
            else if (colliderGameObject.name.StartsWith("Sword"))
            {
                
            }
        }
    }
}
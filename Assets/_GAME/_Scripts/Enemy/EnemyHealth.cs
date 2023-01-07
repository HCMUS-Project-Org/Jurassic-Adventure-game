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
        Enemy.Bunny     => 5,
        Enemy.Ghost     => 3,
        Enemy.AngryBird => 3,
        Enemy.Bat       => 3,
        Enemy.Chamelon  => 3,
        Enemy.Chicken   => 3,
        Enemy.Mushroom  => 3,
        Enemy.Radish    => 3,
        Enemy.Rino      => 3,
        Enemy.Rock      => 3,
        Enemy.SlimeKing => 20
    };

    private                 int currentHealth;
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
            if (_enemyController != null)
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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthBar             _healthBar;
    private                  Animator              _animator;
    private                  PlayerMovement        _playerMovement;
    private                  TMPro.TextMeshProUGUI _healthShow;
    private                  GameController        _gameController;

    public Instruction manaAnnounce;

    private float _timerDisplay;

    public static int maxHealth = 2;
    public static int currentHealth;
    public int maxMana = 10;
    public int currentMana;

    public static int defense = 0;

    void Start()
    {
        _animator = GetComponent<PlayerController>().animator;
        _playerMovement = GetComponent<PlayerMovement>();
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;

        currentHealth = maxHealth;

        _healthShow      = GameObject.Find("PropertyText").GetComponent<TextMeshProUGUI>();
        _healthShow.text = "Health: " + currentHealth;
    }

    // private void Update()
    // {
    //     _healthShow.text = "Health: " + currentHealth;
    // }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            amount += defense;
            amount =  Mathf.Min(amount, 0);
            
            // case die
            if (currentHealth <= 1) 
            {
                PlayerController.currentLife -= 1;

                // show die count down
                if (PlayerController.currentLife > 0) 
                    _gameController.ShowDieCountDown();

                // Die animate
                _playerMovement.enabled = false;
                _animator.SetBool("IsRun", false);
                _animator.SetTrigger("Die");

                amount = -9999;
            } 
            else 
                _animator.SetTrigger("Hurt");
        }

        // set value
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        _healthBar.instance.SetHealthValue(currentHealth / (float)maxHealth);
        
        // case over life -> game over
        if (PlayerController.currentLife <= 0)
            _gameController.ShowLevelFailedUI();

        Debug.Log("Player health:" + currentHealth + "/" + maxHealth);
    }

    public void ChangeMana(int amount)
    {
        if (amount < 0 && currentMana <= 0)
        {
            Debug.Log("Out mana");
            manaAnnounce.DisplayDialog();
            return;
        }

        // set value
        currentMana = Mathf.Clamp(currentMana + amount, 0, maxMana);
        _healthBar.instance.SetManaValue(currentMana / (float)maxMana);
    }

    public void Heal(int amount)
    {
        ChangeHealth(amount);
    }

    public void RegenMana()
    {
        ChangeMana(4);
    }

    public void RegenLife()
    {   
        int currentLife = PlayerController.currentLife;
        PlayerController.currentLife = Mathf.Clamp(currentLife + 1, 0, PlayerController.maxLife);
    }

    public IEnumerator StartRegen()
    {
        var times = 6;
        while (times > 0)
        {
            Heal(1);
            yield return new WaitForSeconds(2f);
            times--;
        }
    }
}
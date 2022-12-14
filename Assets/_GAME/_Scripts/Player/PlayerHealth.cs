using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private Animator animator;
    private TMPro.TextMeshProUGUI healthShow; 

    void Start()
    {
        animator = GetComponent<PlayerController>().animator;
        healthShow = GameObject.Find("PropertyText").GetComponent<TextMeshProUGUI>();    
     
        currentHealth = maxHealth;
        healthShow.text = "Health: " + currentHealth;
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            animator.SetTrigger("Hurt");
            // PlaySound(triggerClip);

            // if (isInvincible)
            //     return;

            // isInvincible = true;
            // invincibleTimer = timeInvincible;
        }

        // set value
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        HealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        healthShow.text = "Health: " + currentHealth;

        Debug.Log("Player health:" + currentHealth + "/" + maxHealth);
    }
}

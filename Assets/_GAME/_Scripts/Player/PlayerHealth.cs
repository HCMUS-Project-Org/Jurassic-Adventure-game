using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<PlayerController>().animator;
        currentHealth = maxHealth;
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

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("Player health:" + currentHealth + "/" + maxHealth);
    }
}

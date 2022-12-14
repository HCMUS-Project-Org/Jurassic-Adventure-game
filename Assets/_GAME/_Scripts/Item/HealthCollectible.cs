using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        
        if (controller != null)
        {
            if (controller.health.currentHealth < controller.health.maxHealth)
            {
                controller.health.ChangeHealth(1);
                Destroy(gameObject);
            }        
        }
    }
}

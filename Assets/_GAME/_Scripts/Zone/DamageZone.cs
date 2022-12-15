using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour {

    [SerializeField] private int damage = 1;


    void OnTriggerEnter2D(Collider2D collision) {
        PlayerController controller = collision.GetComponent<PlayerController>();
        
        if (controller != null) {
            controller.health.ChangeHealth(-damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public PlayerHealth health;
    private Rigidbody2D rigidbody2d;


    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();
    }

    private void Update() {
        Debug.Log(health.currentHealth + "/" + health.maxHealth);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Rigidbody2D _rigidbody2d;
    public int damage = 1;

    void Awake() {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }


    void Update() {
        if (transform.position.magnitude > 100.0f ) {
            Destroy(gameObject);
        }
    }


    public void Launch(Vector2 direction, float force) {
        if (direction.x < 0) {
            Flip();
        }
        
        _rigidbody2d.AddForce(direction * force);
    }


    void OnCollisionEnter2D(Collision2D collision) {
        //we also add a debug log to know what the projectile touch
        
        EnemyController enemy = collision.collider.GetComponent<EnemyController>();
        
        if (enemy != null) {
            enemy.health.ChangeHealth(-damage);
        }

        Destroy(gameObject);
    }

    private void Flip() {
        transform.Rotate(0f, 180f, 0f);
    }
}

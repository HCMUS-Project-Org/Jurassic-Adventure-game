using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;
    public  int         damage = 1;

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // if (transform.position.magnitude > 100.0f)
        // {
        //     Destroy(gameObject);
        // }
    }


    public void Launch(Vector2 direction, float force)
    {
        if (direction.x < 0)
        {
            Flip();
        }

        _rigidbody2d.AddForce(direction * force);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyController enemy))
        {
            enemy.health.GetDamage(damage);
            Destroy(gameObject);
        }
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
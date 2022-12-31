using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enemy
{
    Bunny
}

public enum EnemyState
{
    Idle,
    Chasing,
    Death
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy      enemy;
    private                  EnemyState enemyState;

    [SerializeField] private float _speed      = 3.0f;
    [SerializeField] private float _changeTime = 3.0f;
    private                  float _timer;

    [SerializeField] private int maxHealth  = 1;
    private                  int _direction = 1;

    private Rigidbody2D _rigidbody2D;

    public                   EnemyHealth health;
    [SerializeField] private Animator    animator;

    private float GetEnemySpeed() => enemy switch
    {
        Enemy.Bunny => 5f,
    };

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _timer       = _changeTime;
        Flip();
    }

    private                 Ray enemyForwardRay;
    private static readonly int Running = Animator.StringToHash("running");

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            _direction = -_direction;
            _timer     = _changeTime;
            Flip();
        }

        ChangeEnemyState(CheckFoundPlayer() ? EnemyState.Chasing : EnemyState.Idle);
    }

    bool CheckFoundPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            new Vector2(transform.position.x + 2, transform.position.y),
            - transform.right,
            12f,
            1 << LayerMask.NameToLayer("Character"));

        return hit.collider != null && hit.collider.CompareTag("Player");
    }

    void FixedUpdate()
    {
        Vector2 position = _rigidbody2D.position;

        position.x += Time.deltaTime * _speed * _direction;

        _rigidbody2D.MovePosition(position);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.health.ChangeHealth(-1);
        }
    }


    public void Killed()
    {
        Destroy(gameObject);
    }


    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        health.healthBar.transform.Rotate(0f, 180f, 0f);
    }


    private void ChangeEnemyState(EnemyState newState)
    {
        switch (newState)
        {
            case EnemyState.Idle:
                _speed = 0f;
                animator.SetBool(Running, false);
                break;
            case EnemyState.Chasing:
                _speed = GetEnemySpeed();
                animator.SetBool(Running, true);
                break;
            case EnemyState.Death:
                break;
        }

        enemyState = newState;
    }
}
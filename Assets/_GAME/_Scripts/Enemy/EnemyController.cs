using UnityEngine;

public enum Enemy
{
    Bunny,
    Ghost,
    AngryBird,
    Bat,
    Chamelon,
    Chicken,
    Mushroom,
    Radish,
    Rino,
    Rock
}

public enum EnemyState
{
    Idle,
    Chasing,
    Death
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Enemy      enemy;
    private                 EnemyState enemyState;

    [SerializeField] private float _changeTime = 3.0f;
    private                  float _speed;
    private                  float _timer;

    // [SerializeField] private int maxHealth  = 1;
    private int _direction = 1;

    private Rigidbody2D _rigidbody2D;

    public                   EnemyHealth health;
    [SerializeField] private Animator    animator;
    [SerializeField] private GameObject  DropPrefab;


    private float GetEnemyIdleSpeed() => enemy switch
    {
        Enemy.Bunny => 0f,
        Enemy.Ghost => 1.2f,
        Enemy.AngryBird => 0f,
        Enemy.Bat => 0f,
        Enemy.Chamelon => 0f,
        Enemy.Chicken => 0f,
        Enemy.Mushroom => 0f,
        Enemy.Radish => 0f,
        Enemy.Rino  => 0f,
        Enemy.Rock  => 0f,
    };

    private float GetEnemySpeed() => enemy switch
    {
        Enemy.Bunny => 5f,
        Enemy.Ghost => 10f,
        Enemy.AngryBird => 5f,
        Enemy.Bat => 5f,
        Enemy.Chamelon => 5f,
        Enemy.Chicken => 5f,
        Enemy.Mushroom => 5f,
        Enemy.Radish => 5f,
        Enemy.Rino  => 5f,
        Enemy.Rock  => 5f,
    };

    private float GetChangeTime() => enemy switch
    {
        Enemy.Bunny => 3f,
        Enemy.Ghost => 1.5f,
        Enemy.AngryBird => 3f,
        Enemy.Bat => 3f,
        Enemy.Chamelon => 3f,
        Enemy.Chicken => 3f,
        Enemy.Mushroom => 3f,
        Enemy.Radish => 3f,
        Enemy.Rino  => 3f,
        Enemy.Rock  => 3f,
    };

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _speed       = GetEnemySpeed();
        _changeTime  = GetChangeTime();

        _timer = _changeTime;
        animator.SetTrigger(enemy.ToString());
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
            -transform.right,
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

            // Kill enemy when it killed player
            if (PlayerHealth.currentHealth <= 0)
            {
                Died();
            }
        }
    }

    public void Died()
    {
        ChangeEnemyState(EnemyState.Death);
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
                _speed = GetEnemyIdleSpeed();
                animator.SetBool(Running, false);
                break;
            case EnemyState.Chasing:
                _speed = GetEnemySpeed();
                animator.SetBool(Running, true);
                break;
            case EnemyState.Death:
                Instantiate(DropPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject, .25f);
                break;
        }

        enemyState = newState;
    }
}
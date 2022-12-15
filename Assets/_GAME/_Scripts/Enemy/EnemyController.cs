using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _changeTime = 3.0f;
    
    Rigidbody2D _rigidbody2D;

    float _timer;
    int _direction = 1;


    // Start is called before the first frame update
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _timer = _changeTime;
    }


    void Update() {
        _timer -= Time.deltaTime;

        if (_timer < 0) {
            _direction = -_direction; _timer = _changeTime;
        }
    }


    void FixedUpdate() {
        Vector2 position = _rigidbody2D.position;

        position.x = position.x + Time.deltaTime * _speed * _direction;

        _rigidbody2D.MovePosition(position);
    }


    void OnCollisionEnter2D(Collision2D collision) {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null){
            player.health.ChangeHealth(-1);
        }
    }
}

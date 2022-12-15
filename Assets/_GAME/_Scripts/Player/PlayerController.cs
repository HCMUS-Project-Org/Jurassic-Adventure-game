using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private RuntimeAnimatorController _ninjaController, _knightController;
    private Rigidbody2D _rigidbody2d;

    public PlayerHealth health;
    public Animator animator;


    void Start() {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();

        // SetCharacter(0); //test
        SetCharacter(ChooseCharacter.character);
    }


    void SetCharacter(int characterIdx) {
        if (characterIdx == 0) {
            // ninja
            animator.runtimeAnimatorController = _ninjaController;
            GetComponent<BoxCollider2D>().size = new Vector2(1.28f, 1.87f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.11f, 0.01f);
        }
        else if (characterIdx == 1) {
            // knight
            animator.runtimeAnimatorController = _knightController;
            GetComponent<Transform>().localScale = new Vector3(1.7f, 2f, 1.5f);
            GetComponent<BoxCollider2D>().size = new Vector2(1.075f, 1.458f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.0075f, -0.52f);
        }
    }

}

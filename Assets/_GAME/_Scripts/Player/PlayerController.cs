using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public PlayerHealth health;
    public Animator animator;
    private Rigidbody2D rigidbody2d;
    [SerializeField] private RuntimeAnimatorController NinjaController, KnightController;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();
     
        SetCharacter(1); //test
        // SetCharacter(ChooseCharacter.Character);
    }

    void SetCharacter(int characterIdx) {
        if (characterIdx == 0) {
            // ninja
            animator.runtimeAnimatorController = NinjaController;
            GetComponent<BoxCollider2D>().size = new Vector2(1.28f, 1.87f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.11f, 0.01f);
        }
        else if (characterIdx == 1) {
            // knight
            animator.runtimeAnimatorController = KnightController;
            GetComponent<Transform>().localScale = new Vector3(1.7f, 2f, 1.5f);
            GetComponent<BoxCollider2D>().size = new Vector2(1.075f, 1.458f);
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.0075f, -0.52f);
        }
    }

    private void Update() {
    }
    
}

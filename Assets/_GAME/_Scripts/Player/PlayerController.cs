using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private RuntimeAnimatorController _ninjaController, _knightController;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private UIInventory _inventoryMenu;
    [SerializeField] private GameObject _uiInventory;

    private                  InventoryManager _inventoryManager;

    public static int budget = 50;
    
    public PlayerHealth health;
    public Animator animator;



    void Awake() {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();
  
        // SetCharacter(0); //test
        SetCharacter(ChooseCharacter.character);
    }

    void Start() {
        _uiInventory.SetActive(true);
        _inventoryManager = new InventoryManager();
        _inventoryMenu.SetInventory(_inventoryManager);
        _uiInventory.SetActive(false);

    }
    void Update() {
        ReadInstruction();
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


    void ReadInstruction() {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody2d.position,
        transform.TransformDirection(Vector3.forward), 1.5f, LayerMask.GetMask("Instruction"));
       
        if (hit.collider != null) {
            Instruction instruction = hit.collider.GetComponent<Instruction>();
            
            if (instruction != null) {
                instruction.DisplayDialog();
            }
        }
    }
}

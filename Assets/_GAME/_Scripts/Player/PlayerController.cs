using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private UIInventory _inventoryMenu;
    [SerializeField] private GameObject _uiInventory;
    private                  InventoryManager _inventoryManager;
    private                  EquipmentManager _equipmentManager;
    private                  Character _character;

    public static int budget = 0;
    public static int maxLife = 3;
    public static int currentLife = maxLife;
    public static int score = 0;
    
    public PlayerHealth health;
    public Animator animator;

    void Awake() {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();    
    }


    void Start() {
        _character = FindObjectOfType(typeof(Character)) as Character; 

        _uiInventory.SetActive(true);
        _inventoryManager = new InventoryManager();
        _equipmentManager = new EquipmentManager();
        _inventoryMenu.SetInventory(_inventoryManager);
        _uiInventory.SetActive(false);

        SetCharacter(ChooseCharacter.characterType);

    }


    void Update() {
        ReadInstruction();
    }


    void SetCharacter(Character.Type characterType) {
        animator.runtimeAnimatorController = _character.GetAnimatorController(characterType);

        GameObject Avatar =  GameObject.FindGameObjectsWithTag("Avatar")[0];
        Avatar.GetComponent<Image>().sprite = _character.GetAvatar(characterType);

        TMPro.TextMeshProUGUI Name =  GameObject.FindGameObjectsWithTag("Name")[0].GetComponent<TextMeshProUGUI>();
        Name.text = ChooseCharacter.characterType.ToString();

        GetComponent<BoxCollider2D>().size = _character.GetBoxColliderSize(characterType);
        GetComponent<BoxCollider2D>().offset = _character.GetBoxColliderOffset(characterType);
        
        GetComponent<Transform>().localScale = _character.GetLocalScale(characterType);
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

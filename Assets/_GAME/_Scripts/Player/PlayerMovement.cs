using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private Sprite jumpSprite, moveSprite;

    public float _speed = 5;
    public float jumpVelocity = 1;

    private bool facingRight = true;
    private bool moveRight = true;
    
    private Rigidbody2D _rigidbody2d;
    private BoxCollider2D _boxCollider2d;


    private void Awake() {
        _rigidbody2d= transform.GetComponent<Rigidbody2D>();
        _boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }


    private void Update() {
        if (Input.GetButtonDown("Jump") && IsGrounded()) 
            _rigidbody2d.velocity = Vector2.up * jumpVelocity;

        HandleMovement();

        ChangeSprite();
    }


    private void HandleMovement() {
        var movement = Input.GetAxis("Horizontal");
        
        moveRight = movement > 0 ? true : false;

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * _speed;
    }


    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2d.bounds.center, _boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
        
        Debug.Log(raycastHit2D.collider);

        return raycastHit2D.collider != null;
    }


    private void ChangeSprite() {
         // jump
        if (IsGrounded()) {
            GetComponent<SpriteRenderer>().sprite = moveSprite;
        } else {
            GetComponent<SpriteRenderer>().sprite = jumpSprite;
        }

        // flip the player
        if ((moveRight && !facingRight) || (!moveRight && facingRight)) {
            Flip();
        }
    }


    private void Flip() {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
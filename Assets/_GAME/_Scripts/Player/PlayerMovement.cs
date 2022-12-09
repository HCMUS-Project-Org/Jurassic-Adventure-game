using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private Animator animator;
    // [SerializeField] private Sprite jumpSprite, moveSprite, dashSprite;

    public float _speed = 5;
    public float jumpVelocity = 1;
    private float movement = 0f;

    private bool facingRight = true;
    private bool moveRight = true;
    private bool isCrouch = false;
    private bool isCrouchDash = false;

    private Rigidbody2D _rigidbody2d;
    private BoxCollider2D _boxCollider2d;


    private void Awake() {
        _rigidbody2d= transform.GetComponent<Rigidbody2D>();
        _boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }


    private void Update() {
        if (IsGrounded()) {
            // jump
            if (Input.GetButtonDown("Jump"))  {
                _rigidbody2d.velocity = Vector2.up * jumpVelocity;
                animator.SetBool("IsJump", true);
                animator.SetBool("IsRun", false);
            }
            // crouch
            isCrouch = Input.GetKey(KeyCode.LeftControl);

            // crouch dash
            isCrouchDash = Input.GetKey(KeyCode.LeftShift);

        } 

        // melee
        if (Input.GetKeyDown(KeyCode.Mouse1))
            animator.SetTrigger("IsMelee");                

        HandleMovement();
    }


    private void HandleMovement() {
        // Debug.Log("isCrouchDash: " + isCrouchDash);
        movement = Input.GetAxis("Horizontal");
        
        if (!IsGrounded()) {
            animator.SetBool("IsJump", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsCrouch", false);
            animator.SetBool("IsCrouchDash", false);

        } else {
            animator.SetBool("IsJump", false);

            if (movement == 0f) {
                animator.SetBool("IsRun", false);
                animator.SetBool("IsCrouch", isCrouch);
                animator.SetBool("IsCrouchDash", isCrouchDash);

            } else if (movement != 0f) {
                if (isCrouch) {
                    animator.SetBool("IsRun", false);
                    animator.SetBool("IsCrouchDash", false);
                    animator.SetBool("IsCrouch", true);

                } else if (isCrouchDash) {
                    animator.SetBool("IsRun", false);
                    animator.SetBool("IsCrouch", false);
                    animator.SetBool("IsCrouchDash", true);

                } else {
                    animator.SetBool("IsRun", true);
                    animator.SetBool("IsCrouch", false);
                    animator.SetBool("IsCrouchDash", false);
                }
            }
        }

        moveRight = movement > 0 ? true : false;

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * _speed;

        if ((moveRight && !facingRight) || (!moveRight && facingRight)) {
            Flip();
        }
    }


    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2d.bounds.center, _boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
        // Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }


    private void Flip() {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] private LayerMask _platformLayerMask;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpVelocity = 1;

    private float _movement = 0f;

    private bool _facingRight = true;
    private bool _moveRight = true;
    private bool _isCrouch = false;
    private bool _isCrouchDash = false;

    private Rigidbody2D _rigidbody2d;
    private BoxCollider2D _boxCollider2d;
    private Animator _animator;


    private void Start() {
        _rigidbody2d= transform.GetComponent<Rigidbody2D>();
        _boxCollider2d = transform.GetComponent<BoxCollider2D>();
        _animator = GetComponent<PlayerController>().animator;
    }


    private void Update() {
        if (IsGrounded()) {
            // jump
            if (Input.GetButtonDown("Jump"))  {
                _rigidbody2d.velocity = Vector2.up * _jumpVelocity;
                _animator.SetBool("IsJump", true);
                _animator.SetBool("IsRun", false);
            }
            
            // crouch
            _isCrouch = Input.GetKey(KeyCode.LeftControl);

            // crouch dash
            _isCrouchDash = Input.GetKey(KeyCode.LeftShift);
        } 

        // melee
        if (Input.GetKeyDown(KeyCode.Mouse1))
            _animator.SetTrigger("Melee");   
        
        // skill
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _animator.SetTrigger("Skill");                

        HandleMovement();
    }


    private void HandleMovement() {
        _movement = Input.GetAxis("Horizontal");
        
        if (!IsGrounded()) {
            _animator.SetBool("IsJump", true);
            _animator.SetBool("IsRun", false);
            _animator.SetBool("IsCrouch", false);
            _animator.SetBool("IsCrouchDash", false);
        } 
        else {
            _animator.SetBool("IsJump", false);

            if (_movement == 0f) {
                _animator.SetBool("IsRun", false);
                _animator.SetBool("IsCrouch", _isCrouch);
                _animator.SetBool("IsCrouchDash", _isCrouchDash);

            } else if (_movement != 0f) {
                if (_isCrouch) {
                    _animator.SetBool("IsRun", false);
                    _animator.SetBool("IsCrouchDash", false);
                    _animator.SetBool("IsCrouch", true);

                } else if (_isCrouchDash) {
                    _animator.SetBool("IsRun", false);
                    _animator.SetBool("IsCrouch", false);
                    _animator.SetBool("IsCrouchDash", true);

                } else {
                    _animator.SetBool("IsRun", true);
                    _animator.SetBool("IsCrouch", false);
                    _animator.SetBool("IsCrouchDash", false);
                }
            }
        }

        _moveRight = _movement > 0 ? true : false;

        transform.position += new Vector3(_movement, 0, 0) * Time.deltaTime * _speed;

        if ((_moveRight && !_facingRight) || (!_moveRight && _facingRight)) {
            Flip();
        }
    }


    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2d.bounds.center, _boxCollider2d.bounds.size, 0f, Vector2.down, .1f, _platformLayerMask);
        // Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }


    private void Flip() {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
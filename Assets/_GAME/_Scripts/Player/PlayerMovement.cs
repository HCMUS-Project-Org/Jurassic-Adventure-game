using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private LayerMask _platformLayerMask;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerHealth _playerHealth;
    private                  Rigidbody2D _rigidbody2d;
    private                  BoxCollider2D _boxCollider2d;
    private                  Vector2 _lookDirection = new Vector2(1, 0);
    private                  Animator _animator;
    
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpVelocity = 1;
    private                  float _movement = 0f;

    private bool _facingRight = true;
    private bool _moveRight = true;
    private bool _isCrouch = false;
    private bool _isCrouchDash = false;
    
    public GameObject projectilePrefab;
    

    private void Start() {
        _rigidbody2d= transform.GetComponent<Rigidbody2D>();
        _boxCollider2d = transform.GetComponent<BoxCollider2D>();
        _animator = GetComponent<PlayerController>().animator;
    }


    private void Update()
    {
        _isGrounded = IsGrounded;
        
        if (IsGrounded) {
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
            Launch();           

        HandleMovement();
    }


    private void HandleMovement() {
        _movement = Input.GetAxis("Horizontal");
        
        if (!IsGrounded) {
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

        if (_movement == 0f) 
            _moveRight = _facingRight;
        else
            _moveRight = _movement > 0 ? true : false;

        transform.position += new Vector3(_movement, 0, 0) * Time.deltaTime * _speed;

        if ((_moveRight && !_facingRight) || (!_moveRight && _facingRight)) {
            Flip();
        }
    }


    private bool _isGrounded;
    
    private bool IsGrounded =>
        Physics2D.BoxCast(_boxCollider2d.bounds.center, _boxCollider2d.bounds.size, 0f, Vector2.down, .1f, _platformLayerMask).collider != null;
        



    private void Flip() {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    public void Launch() {
        if (_playerController.health.currentMana <= 0) {
            _playerHealth.manaAnnounce.DisplayDialog();
            return;
        }

        _playerController.health.ChangeMana(-1);

        _animator.SetTrigger("Skill");     


        _lookDirection.Set(_facingRight ? 1 : -1, 0);

        GameObject projectileObject = Instantiate(projectilePrefab, _rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();

        projectile.Launch(_lookDirection, 300);

        // decrease mana

        _animator.SetTrigger("Launch");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Properties 
    public bool Grappling
    {
        get { return _isGrappling; }
        set { _isGrappling = value; }
    }

    public int Cookies
    {
        get { return _cookies; }
    }

    // Fields 
    [SerializeField] private float _speed = 40f;
    [SerializeField] private Text _pointsText;

    private CharacterController2D _characterController;
    private Animator _playerAnimator;
    private Rigidbody2D _rb;
    private bool _hasToJump = false;
    private bool _isGrappling = false;
    private int _cookies = 0;
    private PlayerSound _sound;
    private float _xSpeed;

    // Unity Methods 
    private void Awake()
    {
        _sound = GetComponent<PlayerSound>();
        _playerAnimator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _characterController = GetComponent<CharacterController2D>();
    }

    void Update()
    {
        float ySpeed = _rb.velocity.y;
        bool isGrounded = _characterController.Grounded();

        _playerAnimator.SetFloat("JumpSpeed", ySpeed);
        _playerAnimator.SetBool("Grounded", isGrounded);

        _xSpeed = Input.GetAxisRaw("Horizontal") * _speed;
        if (_isGrappling) _xSpeed *= 2f;

        _playerAnimator.SetFloat("MoveSpeed", Mathf.Abs(_xSpeed));

        if (Input.GetButtonDown("Jump"))
        {
            _hasToJump = true;
        }
    }

    void FixedUpdate()
    {
        _characterController.Move(_xSpeed * Time.fixedDeltaTime, _hasToJump);
        _hasToJump = false;
    }

    // Other Methods 
    public void AddCookie()
    {
        _cookies += 10;
        _sound.PlayCookie();
        DisplayPoints();
    }

    private void DisplayPoints()
    {
        int cen, dec, unit;

        cen = _cookies/100 % 10;
        dec = _cookies/10 % 10;
        unit = _cookies % 10;

        _pointsText.text = cen.ToString() + dec.ToString() + unit.ToString();
    }
}

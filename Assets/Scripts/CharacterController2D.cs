using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	// Properties
	// Fields
	[SerializeField] private float _jumpForce = 400f;                          
	[SerializeField] private float _coyoteTime = 0.1f;                         
	[Range(0, .3f)] [SerializeField] private float _movementSmoothing = .05f;  
	[Range(0, .3f)] [SerializeField] private float _airMovementSmoothing = .05f;  
	[SerializeField] private bool _airControl = false;							
	[SerializeField] private LayerMask _groundMask;							
	[SerializeField] private Transform _groundCheck;                           
	                          
	const float GroundedRadius = 0.2f; 
	private bool _isGrounded;            
	private Rigidbody2D _rb;
	private bool _facingRight = true;  
	private Vector3 _velocity = Vector3.zero;
	private float _coyoteTimer;
	private PlayerSound _sound;

	// Unity Methods
	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		_sound = GetComponent<PlayerSound>();
	}

    private void FixedUpdate()
	{
		bool wasGrounded = _isGrounded;
		_isGrounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, GroundedRadius, _groundMask);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				_isGrounded = true;
				if (!wasGrounded) _sound.PlayStep();
			}
		}

		if (wasGrounded)
        {
			_coyoteTimer = _coyoteTime;
        }
	}

    public void Update()
    {
		if (!_isGrounded) _coyoteTimer -= Time.deltaTime;
    }
	
	// Other Methods
    public void Move(float move, bool jump)
	{
		if (_isGrounded || (_airControl && move != 0))
		{
			Vector3 targetVelocity = new Vector2(move * 10f, _rb.velocity.y);
			if (_isGrounded) _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, _movementSmoothing);
			else
            {
				if (move > 0 && targetVelocity.x > 0 || move < 0 && targetVelocity.x < 0) _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, _airMovementSmoothing * 3);
				else _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, _airMovementSmoothing);
			}
            

			if (move > 0 && !_facingRight)
			{
				Flip();
			}
			else if (move < 0 && _facingRight)
			{
				Flip();
			}
		}

		if ((_isGrounded || _coyoteTimer > 0) && jump)
		{
			Jump();
		}
	}

    public bool Grounded()
    {
        return _isGrounded;
    }

	private void Jump()
    {
		_isGrounded = false;
		_coyoteTimer = 0;
		_rb.AddForce(new Vector2(0f, _jumpForce));
		_sound.PlayJump();
	}
	private void Flip()
	{
		_facingRight = !_facingRight;
		transform.Rotate(0f, 180f, 0f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    // Properties
    //Fields
    
    [SerializeField] private AudioSource _grappleSound;
    [SerializeField] private AudioSource _retractSound;
    [SerializeField] private float _impulseForce = 1000f;
    [SerializeField] private float _impulseTime = 0.2f;
    private LineRenderer _lineRenderer;
    private DistanceJoint2D _distanceJoint;
    private Player _player;
    private Transform _leashPoint;

    private bool _isMouseOver = false;
    private bool _isActive = false;
    private Vector2 _lastPosition;
    private float _impulseTimer;
    // Unity Methods
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _lineRenderer = _player.GetComponent<LineRenderer>();
        _distanceJoint = _player.GetComponent<DistanceJoint2D>();
        _leashPoint = _player.transform.GetChild(1).transform;
        _distanceJoint.enabled = false;
        _lastPosition = _player.transform.position;
    }

    void OnMouseOver()
    {
        _isMouseOver = true;
    }

    private void OnMouseExit()
    {
        _isMouseOver = false;
    }

    private void Update()
    {
        _impulseTimer -= Time.deltaTime;
        Vector2 playerDirection = (Vector2)_player.transform.position - _lastPosition;
        Vector2 grappleDirection = (Vector2)transform.position - (Vector2)_player.transform.position;
        Vector2 impulseDirecton = playerDirection + grappleDirection;
        if (Input.GetKeyDown(KeyCode.Mouse0) && _isMouseOver)
        {
            _grappleSound.Play();
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _leashPoint.position);
            _distanceJoint.connectedAnchor = transform.position;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
            _player.Grappling = true;
            _distanceJoint.distance = Vector2.Distance(_leashPoint.position, transform.position);
            _isActive = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _retractSound.Stop();
            if (_impulseTimer > 0)
            {
                Debug.Log("We add force");
                _player.GetComponent<Rigidbody2D>().AddForce(impulseDirecton.normalized * _impulseForce, ForceMode2D.Impulse);
            } 
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
            _player.Grappling = false;
            _isActive = false;
        }

        if (_isActive)
        {
            if ((Input.GetKeyDown (KeyCode.Mouse1))) _retractSound.Play();
            if (Input.GetKey(KeyCode.Mouse1))
            {
                _impulseTimer = _impulseTime;
                if (!_retractSound.isPlaying) _retractSound.Play();
                _distanceJoint.distance = 1f;
            }

            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                _retractSound.Stop();
                _distanceJoint.distance = Vector2.Distance(_leashPoint.position, transform.position);
            }

            _lineRenderer.SetPosition(1, _leashPoint.position);
        }
    }

    private void FixedUpdate()
    {
        _lastPosition = _player.transform.position;
    }
    // Other Methods
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    // Properties
    //Fields
    
    [SerializeField] private AudioSource _grappleSound;
    [SerializeField] private AudioSource _retractSound;

    private LineRenderer _lineRenderer;
    private DistanceJoint2D _distanceJoint;
    private Player _player;
    private Transform _leashPoint;

    private bool _isMouseOver = false;
    private bool _isActive = false;
    // Unity Methods
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _lineRenderer = _player.GetComponent<LineRenderer>();
        _distanceJoint = _player.GetComponent<DistanceJoint2D>();
        _leashPoint = _player.transform.GetChild(1).transform;
        _distanceJoint.enabled = false;
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
    // Other Methods
}

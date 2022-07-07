using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Properties
    // Fields
    private Transform _player;
    private Camera _cam;
    private Vector2 _startPosition;
    private float _startZ;
    private Vector2 _travel => (Vector2)_cam.transform.position - _startPosition;
    private float _distanceFromSubject => transform.position.z - _player.position.z;
    private float _clippingPlane => (_cam.transform.position.z + (_distanceFromSubject > 0 ? _cam.farClipPlane : _cam.nearClipPlane));
    private float _parallaxFactor => Mathf.Abs(_distanceFromSubject)/_clippingPlane;

    // Unity Methods
    void Start()
    {
        _player = FindObjectOfType<Player>().transform;
        _cam = FindObjectOfType<Camera>();
        _startPosition = transform.position;
        _startZ = transform.position.z;
    }
    void Update()
    {
        Vector2 newPos = _startPosition + _travel * _parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, _startZ);
    }
    // Other Methods
}

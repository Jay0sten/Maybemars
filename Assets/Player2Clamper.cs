using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Clamper : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    private Rigidbody2D _rb;
    [SerializeField] private float _xMax;
    [SerializeField] private float _xMin;

    private void Start()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _xMax = (_camera.transform.position.x + (_camera.orthographicSize * _camera.aspect)) - 0.5f;
        _xMin = (_camera.transform.position.x - (_camera.orthographicSize * _camera.aspect)) + 0.5f;
        if(transform.position.x > _xMax)
        {
            transform.position = new Vector3(_xMax - 0.001f, transform.position.y, transform.position.z);
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        }
        else if(transform.position.x < _xMin)
        {
            transform.position = new Vector3(_xMin, transform.position.y, transform.position.z);
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        }
    }
}

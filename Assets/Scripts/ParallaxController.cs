using System;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxController : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private int _repeatCount = 2;
    [SerializeField] private float _paralaxValue;
    [SerializeField] private Transform _secondImageTransform;
    [SerializeField] private float _offset;

    private float _length;
    private float _prevCamera;
    void Start()
    {
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
        _length -= 0.01f;
        _prevCamera = _camera.transform.position.x;
        if (_secondImageTransform != null)
        {
            _secondImageTransform.position = new Vector3(transform.position.x + _length, transform.position.y, transform.position.z);
        }
    }

    void Update()
    {
        float cameraPosition = _camera.transform.position.x;
        float speed = cameraPosition - _prevCamera;
        transform.position = new Vector3(transform.position.x + _paralaxValue * speed, transform.position.y, transform.position.z);
        if(cameraPosition > transform.position.x + _length + _offset) {
            transform.position = new Vector3(transform.position.x + _repeatCount * _length, transform.position.y, transform.position.z);
        }
        _prevCamera = _camera.transform.position.x;
    }
}
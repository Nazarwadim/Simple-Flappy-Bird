using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private Transform _followObject;
    [SerializeField] private float _offset;

    [SerializeField] private Pipe _prefab;
    [SerializeField] private int _seed;


    [SerializeField, Min(0f)] private float _minHole = 2;
    [SerializeField, Min(0f)] private float _maxHole = 5;

    [SerializeField, Range(-6f, 6f)] private float _minHeigth = -6;
    [SerializeField, Range(-6f, 6f)] private float _maxHeigth = 6;

    [SerializeField, Range(0f, 5f)] private float _minTimeToWait = 1;
    [SerializeField, Range(0f, 5f)] private float _maxTimeToWait = 1;

    private System.Random _random;
    private bool _isCourutineWorking;
    private bool _isWorking;

    public bool IsWorking
    {
        get { return _isWorking; }
        set
        {
            _isWorking = value;
            if (!_isCourutineWorking && _isWorking)
            {
                StartCoroutine(PipeGenerateCoroutine());
            }
        }
    }

    private void OnValidate()
    {
        if (_minTimeToWait > _maxTimeToWait)
        {
            _minTimeToWait = _maxTimeToWait;
        }
        if (_minHole > _maxHole)
        {
            _minHole = _maxHole;
        }
        if (_minHeigth > _maxHeigth)
        {
            _minHeigth = _maxHeigth;
        }
    }

    private void Awake()
    {
        _random = new System.Random(_seed);
    }


    private void Start()
    {
        IsWorking = true;
    }

    private IEnumerator PipeGenerateCoroutine()
    {
        _isCourutineWorking = true;
        while (IsWorking)
        {
            int waitTimems = _random.Next((int)_minTimeToWait * 1000, (int)_maxTimeToWait * 1000);
            float waitTime = waitTimems / 1000.0f;
            Pipe pipe = GeneratePipe();
            float hole = _random.Next((int)(1000 * _minHole), (int)(1000 * _maxHole)) / 1000.0f;
            float yPosition = _random.Next((int)(1000 * _minHeigth), (int)(1000 * _maxHeigth)) / 1000.0f;
            pipe.SetHoleSize(hole);
            pipe.SetYPosition(yPosition);

            yield return new WaitForSeconds(waitTime);
        }

        _isCourutineWorking = false;
    }

    private Pipe GeneratePipe()
    {
        Pipe pipe = Instantiate(_prefab, transform);
        pipe.transform.position = new Vector3(_followObject.position.x + _offset, 0, 0);
        return pipe;
    }

    public void Clear() {
        foreach(Transform children in transform) {
            if(children.TryGetComponent(out Pipe pipe)) {
                Destroy(pipe.gameObject);
            }    
        }
    }
}

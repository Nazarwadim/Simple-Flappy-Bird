using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BirdAnimation))]
public class BirdMovement : MonoBehaviour
{
    [SerializeField] private float _speedUpToShowUp;
    [SerializeField] private float _speedDownToShowDown;
    [SerializeField] private float _rotatationSpeed;
    [SerializeField] private float _rotationMax;
    [SerializeField] private float _rotationMin;

    [SerializeField] private float _speed;
    [SerializeField] private float _speedJump;
    private Rigidbody2D _rigid;
    private BirdAnimation _animation;

    private void Start()
    {
        _animation = GetComponent<BirdAnimation>();
        _rigid = GetComponent<Rigidbody2D>();
        _rigid.velocity = new Vector2(_speed, 0);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.velocity = new Vector2(_speed, _speedJump);
        }
    }

    
    private void FixedUpdate()
    {
        if (_rigid.velocity.y > _speedUpToShowUp)
        {
            _rigid.angularVelocity = _rotatationSpeed;
            _animation.SetUpSprite();
        }
        else if (_rigid.velocity.y < _speedDownToShowDown)
        {
            _rigid.angularVelocity = -_rotatationSpeed;
            _animation.SetDownSprite();
        }
        else
        {
            _animation.SetMiddleSprite();
        }
        Vector3 rot = transform.rotation.eulerAngles;
        if(rot.z > 180) {
            rot.z -= 360;
        }
        
        rot.z = Mathf.Clamp(rot.z, _rotationMin, _rotationMax);
        transform.rotation = Quaternion.Euler(rot);
    }

}

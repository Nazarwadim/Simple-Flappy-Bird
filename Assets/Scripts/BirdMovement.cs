using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BirdAnimation), typeof(BirdCollisionHandler))]
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

    private bool _canMove;

    private bool _isGoingToJump = false;
    public bool CanMove
    {
        get { return _canMove; }
        set
        {
            _canMove = value;

            enabled = value;
            _rigid.simulated = value;

        }
    }

    private void OnEnable()
    {
        _animation = GetComponent<BirdAnimation>();
        _rigid = GetComponent<Rigidbody2D>();
        _rigid.velocity = new Vector2(_speed, 0);
        //CanMove = false;
    }


    private void Update()
    {
        if (CanJump())
        {
            _rigid.velocity = new Vector2(_speed, _speedJump);
        }
    }

    private bool CanJump()
    {
        bool jump = _isGoingToJump || Input.GetKeyDown(KeyCode.Space);
        if (_isGoingToJump == true)
        {
            _isGoingToJump = false;
        }
        return jump;
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
        if (rot.z > 180)
        {
            rot.z -= 360;
        }

        rot.z = Mathf.Clamp(rot.z, _rotationMin, _rotationMax);
        transform.rotation = Quaternion.Euler(rot);
    }

    public void Jump()
    {
        _isGoingToJump = true;
    }

}

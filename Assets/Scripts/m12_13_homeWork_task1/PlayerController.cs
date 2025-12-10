using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";
    private KeyCode JumpKey = KeyCode.Space;

    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _rotationForce;
    [SerializeField] private float _jumpForce;

    [SerializeField] private RotatorRigidbody _rotaterRigidbody;

    private bool _isJump;
    private bool _isOnGround;

    private float _xInput;
    private float _zInput;

    private void Start()
    {
        _rigidBody.maxAngularVelocity = _rotationForce;
    }

    private void Update()
    {
        _xInput = Input.GetAxis(HorizontalAxis);
        _zInput = Input.GetAxis(VerticalAxis);

        if (Input.GetKeyDown(JumpKey) && _isOnGround)
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isOnGround)
        {
            _rotaterRigidbody.RotateProcess(_xInput, _zInput, _rigidBody, _rotationForce);
        }

        if (_isJump)
        {
            _rigidBody.AddForce(Vector3.up * _jumpForce);
            _isJump = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out var groundComponent))
        {
            _isOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out var groundComponent))
        {
            _isOnGround = false;
        }
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";
    private KeyCode JumpKey = KeyCode.Space;

    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _rotationForce;
    [SerializeField] private float _jumpForce;

    private bool _isJump;

    private float _xInput;
    private float _zInput;

    private float _deadZone = 0.05f;

    private void Start()
    {
        _rigidBody.maxAngularVelocity = _rotationForce;
    }

    private void Update()
    {
        _xInput = Input.GetAxis(HorizontalAxis);
        _zInput = Input.GetAxis(VerticalAxis);

        if (Input.GetKeyDown(JumpKey))
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        float koefForce;

        if (Mathf.Abs(_xInput) > _deadZone && Mathf.Abs(_zInput) > _deadZone)
        {
            koefForce = 0.5f;
        }
        else
        {
            koefForce = 1f;
        }

        if (Mathf.Abs(_xInput) > _deadZone)
            _rigidBody.AddTorque(Vector3.back * _rotationForce * _xInput * koefForce);

        if (Mathf.Abs(_zInput) > _deadZone)
            _rigidBody.AddTorque(Vector3.right * _rotationForce * _zInput * koefForce);

        if (_isJump)
        {
            _rigidBody.AddForce(Vector3.up * _jumpForce);
            _isJump = false;
        }
    }
}

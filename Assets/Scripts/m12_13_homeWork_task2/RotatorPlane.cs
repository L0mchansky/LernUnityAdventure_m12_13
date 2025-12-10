using UnityEngine;

public class RotatorPlane : MonoBehaviour
{
    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";

    [SerializeField] private int _sensetive;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Transform _sphereTransform;

    private float _xInput;
    private float _zInput;

    private bool _isRotate;

    private float _deadZone = 0.05f;

    private void Start()
    {
        _sphereTransform.position = _startPosition;
        _sphereTransform.GetComponent<Rigidbody>().WakeUp();
    }

    void Update()
    {
        _xInput = Input.GetAxis(HorizontalAxis);
        _zInput = Input.GetAxis(VerticalAxis);

        if (Mathf.Abs(_xInput) > _deadZone)
            _isRotate = true;

        if (Mathf.Abs(_zInput) > _deadZone)
            _isRotate = true;
    }

    private void FixedUpdate()
    {

        Vector3 rotation = new Vector3(_zInput, 0, -_xInput) * _sensetive * Time.deltaTime;

        if (_isRotate)
        {
            transform.Rotate(rotation);
            _isRotate = false;
        }
    }
}

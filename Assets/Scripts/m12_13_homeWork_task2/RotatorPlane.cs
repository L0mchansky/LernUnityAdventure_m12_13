using UnityEngine;

namespace m12_13_homeWork_task2
{
    public class RotatorPlane : MonoBehaviour
    {
        private string HorizontalAxis = "Horizontal";
        private string VerticalAxis = "Vertical";

        [SerializeField] private int _sensetive;
        [SerializeField] private Rigidbody _rigidbody;

        private float _xInput;
        private float _zInput;

        private bool _isRotate;

        private float _deadZone = 0.05f;

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
            Quaternion quaternion = Quaternion.Euler(rotation);

            if (_isRotate)
            {
                _rigidbody.MoveRotation(_rigidbody.rotation * quaternion);
                _isRotate = false;
            }
        }
    }
}
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private string HorizontalAxis = "Horizontal";
    private KeyCode LaunchKey = KeyCode.Space;

    private Rigidbody _rigidBody;

    private int _coins;

    [SerializeField] private float _force;
    [SerializeField] private float _rotationForce;

    private float _xInput;
    private bool _isLaunched;

    private float _deadZone = 0.05f;

    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    public float CurrentHealth => _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxis(HorizontalAxis);
        _isLaunched = Input.GetKey(LaunchKey);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_xInput) > _deadZone)
            _rigidBody.AddRelativeTorque(Vector3.back * _rotationForce * _xInput);

        if (_isLaunched)
            _rigidBody.AddForce(transform.up * _force);
    }

    public void AddCoin(int value)
    {
        _coins += value;

        Debug.Log(_coins);
    }

    public void TakeDamate(float damage)
    {
        _currentHealth -= damage;

        if(_currentHealth < 0 )
        {
            _currentHealth = 0;
            gameObject.SetActive(false);
            Debug.Log("онцха!");
        }
    }
}

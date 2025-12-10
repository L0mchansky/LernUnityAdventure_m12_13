using UnityEngine;

public class RotatorRigidbody : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    private float _deadZone = 0.05f;
    public void RotateProcess(float xInput, float zInput, Rigidbody rigidBody, float rotationForce)
    {
        float koefAngularForce;
        Vector3 inputXDirection = -_cameraTransform.forward.normalized;
        Vector3 inputZDirection = _cameraTransform.right.normalized;

        if (Mathf.Abs(xInput) > _deadZone && Mathf.Abs(zInput) > _deadZone)
        {
            koefAngularForce = 0.5f;
        }
        else
        {
            koefAngularForce = 1f;
        }

        if (Mathf.Abs(xInput) > _deadZone)
            rigidBody.AddTorque(inputXDirection * rotationForce * xInput * koefAngularForce);

        if (Mathf.Abs(zInput) > _deadZone)
            rigidBody.AddTorque(inputZDirection * rotationForce * zInput * koefAngularForce);
    }
}

using UnityEngine;

public class RotatorCamera : MonoBehaviour
{
    [SerializeField] private float _sensitivity;

    private float _aroundXRotation;
    private float _aroundYRotation;

    private string _mouseAxisX = "Mouse X";
    private string _mouseAxisY = "Mouse Y";

    void Update()
    {
        _aroundXRotation += Input.GetAxis(_mouseAxisX);
        _aroundYRotation += Input.GetAxis(_mouseAxisY);

        Quaternion rotation = Quaternion.Euler(-_aroundYRotation, _aroundXRotation, 0);

        transform.rotation = rotation;
    }
}